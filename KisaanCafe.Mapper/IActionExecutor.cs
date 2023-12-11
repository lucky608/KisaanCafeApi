using Microsoft.AspNetCore.Mvc;

public interface IActionExecutor
    {
        #region Get Executors
        //Task<ActionResult> ExecuteMapWithGetAsync<TQueryResult, TDestination>(Func<Task<TQueryResult>> query) where TQueryResult : class where TDestination : class;
        //Task<IActionResult> ExecuteMapWithGetAsync<TQueryParam, TQueryResult, TDestination>(TQueryParam queryParam, Func<TQueryParam, Task<TQueryResult>> query) where TQueryResult : class where TDestination : class;
        //#endregion

        //#region Validate Executors
        //Task<IActionResult> ExecuteMapWithValidateAsync<TSource, TDestination>(TSource data, Func<TDestination, Task<ValidateActionResult>> validateDataAction) where TSource : class where TDestination : class;
        //#endregion

        //#region Add Executors
        //Task<IActionResult> ExecuteMapWithAddAsync<TSource, TDestination>(TSource data, Func<TDestination, Task<PostActionResult>> addDataAction) where TSource : class where TDestination : class;
        //#endregion

        //#region Update Executors
        //Task<IActionResult> ExecuteMapWithUpdateAsync<TActionParam, TSource, TDestination>(TActionParam actionParam, TSource data, Func<TActionParam, TDestination, Task<PutActionResult>> updateAction) where TSource : class where TDestination : class;

        //#endregion

        //#region Delete Executors
        //Task<IActionResult> ExecuteDeleteAsync<TActionParam>(TActionParam actionParam, Func<TActionParam, Task<DeleteActionResultCode>> deleteAction);
        #endregion
    }

