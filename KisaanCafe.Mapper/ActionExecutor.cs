
    using System;
using System.Threading.Tasks;
using KisaanCafe.Mapper;
using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ActionExecutor : IActionExecutor
    {
        private readonly IMapperClient _mapper;
        private readonly IHttpContextAccessor _http;

        public ActionExecutor(IMapperClient mapper, IHttpContextAccessor http)
        {
            _mapper = mapper.ThrowIfNull(nameof(mapper));
            _http = http.ThrowIfNull(nameof(http));
        }

        #region Get Executors

        //public async Task<ActionResult> ExecuteMapWithGetAsync<TQueryResult, TDestination>(Func<Task<TQueryResult>> query)
        //    where TQueryResult : class
        //    where TDestination : class
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "ExecuteMapWithGetAsync", async () =>
        //    {
        //        var mappedData = await _mapper.MapAsync<TQueryResult, TDestination>(await query().ConfigureAwait(false)).ConfigureAwait(false);

        //        if (mappedData == null)
        //            return new NotFoundObjectResult("Resource not found");

        //        return new OkObjectResult(mappedData);

        //    }).ConfigureAwait(false);
        //}

        //public async Task<IActionResult> ExecuteMapWithGetAsync<TQueryParam, TQueryResult, TDestination>(TQueryParam queryParam, Func<TQueryParam, Task<TQueryResult>> query)
        //    where TQueryResult : class
        //    where TDestination : class
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "ExecuteMapWithGetAsync", async () =>
        //    {
        //        var mappedData = await _mapper.MapAsync<TQueryResult, TDestination>(await query(queryParam).ConfigureAwait(false)).ConfigureAwait(false);

        //        if (mappedData == null)
        //            return new NotFoundObjectResult("Resource not found");

        //        return new OkObjectResult(mappedData);

        //    }).ConfigureAwait(false);
        //}
        //#endregion

        #region Validate Executors
        //public async Task<IActionResult> ExecuteMapWithValidateAsync<TSource, TDestination>(TSource data, Func<TDestination, Task<ValidateActionResult>> validateDataAction)
        //    where TSource : class
        //    where TDestination : class
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "ExecuteMapWithValidate", async () =>
        //    {
        //        var mappedData = await _mapper.MapAsync<TSource, TDestination>(data).ConfigureAwait(false);

        //        var validateActionResult = await validateDataAction(mappedData).ConfigureAwait(false);

        //        if (validateActionResult == null)
        //            throw new ApplicationException($"{nameof(ValidateActionResult)} cannot be null");

        //        return new OkObjectResult(validateActionResult);

        //    }).ConfigureAwait(false);
        //}
        #endregion

        #region Add Executors
        //public async Task<IActionResult> ExecuteMapWithAddAsync<TSource, TDestination>(TSource data, Func<TDestination, Task<PostActionResult>> addDataAction)
        //    where TSource : class
        //    where TDestination : class
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "ExecuteMapWithAdd", async () =>
        //    {
        //        var mappedData = await _mapper.MapAsync<TSource, TDestination>(data).ConfigureAwait(false);

        //        var postActionResult = await addDataAction(mappedData).ConfigureAwait(false);

        //        return MapPostActionResultToActionResult(postActionResult);

        //    }).ConfigureAwait(false);
        //}

        //private IActionResult MapPostActionResultToActionResult(PostActionResult postActionResult)
        //{
        //    if (postActionResult == null)
        //        throw new ApplicationException($"{nameof(PostActionResult)} cannot be null");

        //    if (postActionResult.Result == PostActionResultCode.ResourceAddedSuccessfully)
        //    {
        //        if (!string.IsNullOrEmpty(postActionResult.NewResourceRelativeUrl))
        //            return new CreatedResult(new Uri($"{_http.HttpContext.Request.ExtractPath(3)}{postActionResult.NewResourceRelativeUrl}", UriKind.Relative), postActionResult.NewResourceValue);

        //        return new ObjectResult("Resource created successfully")
        //        {
        //            StatusCode = StatusCodes.Status201Created
        //        };
        //    }
        //    else if (postActionResult.Result == PostActionResultCode.ResourceNotFound)
        //    {
        //        return new NoContentResult();
        //    }

        //    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        //}
        #endregion

        //#region Update Executors
        //public async Task<IActionResult> ExecuteMapWithUpdateAsync<TActionParam, TSource, TDestination>(TActionParam actionParam, TSource data, Func<TActionParam, TDestination, Task<PutActionResult>> updateAction)
        //    where TSource : class
        //    where TDestination : class
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "MapWithUpdate", async () =>
        //    {
        //        var mappedData = _mapper.Map<TSource, TDestination>(data);

        //        var putActionResult = await updateAction(actionParam, mappedData).ConfigureAwait(false);

        //        return MapPutActionResultToActionResult(putActionResult);

        //    }).ConfigureAwait(false);
        //}

        //private IActionResult MapPutActionResultToActionResult(PutActionResult putActionResult)
        //{
        //    if (putActionResult == null)
        //        throw new ApplicationException($"{nameof(PutActionResult)} cannot be null");

        //    if (putActionResult.Result == PutActionResultCode.ResourceUpdatedSuccessfully)
        //    {
        //        return new OkResult();
        //    }
        //    else if (putActionResult.Result == PutActionResultCode.ResourceAddedSuccessfully)
        //    {
        //        if (!string.IsNullOrEmpty(putActionResult.NewResourceRelativeUrl))
        //            return new CreatedResult(new Uri($"{_http.HttpContext.Request.ExtractPath(3)}{putActionResult.NewResourceRelativeUrl}", UriKind.Relative), putActionResult.NewResourceValue);

        //        return new ObjectResult("Resource created successfully")
        //        {
        //            StatusCode = StatusCodes.Status201Created
        //        };
        //    }
        //    else if (putActionResult.Result == PutActionResultCode.ResourceNotFound)
        //        return new NoContentResult();

        //    return new StatusCodeResult(StatusCodes.Status500InternalServerError);

        //}

        //#endregion

        //#region Delete Executors

        //public async Task<IActionResult> ExecuteDeleteAsync<TActionParam>(TActionParam actionParam, Func<TActionParam, Task<DeleteActionResultCode>> deleteAction)
        //{
        //    return (ActionResult)await ExecuteWithCatchAsync("ActionExecutor", "ExecuteDelete", async () =>
        //    {
        //        var resultCode = await deleteAction(actionParam).ConfigureAwait(false);

        //        return MapDeleteActionResultCodeToActionResult(resultCode);
        //    }).ConfigureAwait(false);
        //}

        //private IActionResult MapDeleteActionResultCodeToActionResult(DeleteActionResultCode resultCode)
        //{
        //    if (resultCode == DeleteActionResultCode.ResourceDeletedSuccessfully)
        //        return new OkResult();

        //    else if (resultCode == DeleteActionResultCode.ResourceNotFound)
        //        return new NoContentResult();

        //    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        //}

        //#endregion

        //#region Helpers
        //private async Task<IActionResult> ExecuteWithCatchAsync(string className, string MethodName, Func<Task<IActionResult>> action)
        //{
        //    try
        //    {
        //        return await action().ConfigureAwait(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion
    }

