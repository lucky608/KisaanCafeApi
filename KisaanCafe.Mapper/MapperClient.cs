
using KisaanCafe.Mapper;
using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// This Mapper Client is a general purpose mapper client which can be used by any framework.
    /// </summary>
    public class MapperClient : MapperClientBase
    {
        private readonly string _callerClassName;
        private readonly string _callerMethodName;

    public MapperClient(IMapperResolver mapper) : base(mapper)
    {
    }

    public MapperClient(string callerClassName, string callerMethodName, IMapperResolver mapper) : this(mapper)
    {
        _callerClassName = callerClassName.ThrowIfNull(nameof(callerClassName));
        _callerMethodName = callerMethodName.ThrowIfNull(nameof(callerMethodName));
    }


    public override ExecutingContext GetExecutingContext()
    {
        if (!string.IsNullOrEmpty(_callerClassName) && !string.IsNullOrEmpty(_callerMethodName))
            {
                return new ExecutingContext { ClassName = _callerClassName, MethodName = _callerMethodName };
            }
            else
            {
                var method = new StackTrace().GetFrame(1).GetMethod();
                var executingContext = new ExecutingContext();

                if (method.DeclaringType.GetInterfaces().Any(i => i == typeof(IAsyncStateMachine)))
                {
                    var generatedType = method.DeclaringType;
                    var originalType = generatedType.DeclaringType;
                    var foundMethod = originalType.GetMethods()
                        .SingleOrDefault(m => m.GetCustomAttribute<AsyncStateMachineAttribute>()?.StateMachineType == generatedType);

                    if (foundMethod == null)
                    {
                        foundMethod = originalType.GetMethods().SingleOrDefault(m => m.GetCustomAttribute<AsyncStateMachineAttribute>() != null);
                    }


                    executingContext.ClassName = foundMethod?.DeclaringType.Name;
                    executingContext.MethodName = foundMethod?.Name;
                }
                else
                {
                    executingContext.ClassName = method.DeclaringType.Name;
                    executingContext.MethodName = method.Name;
                }

                return executingContext;
            }
        }
    }

