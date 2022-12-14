using BasicDomain.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace HttpStatusApi.Controllers;

/// <summary>
///     這類的狀態碼代表了客戶端看起來可能發生了錯誤，妨礙了伺服器的處理。
/// </summary>
[Route("api/[controller]")]
[ApiController]
public partial class HttpStatus400Controller : ControllerBase
{
    /// <summary>
    ///     由於明顯的客戶端錯誤（例如，格式錯誤的請求語法，太大的大小，無效的請求訊息或欺騙性路由請求），伺服器不能或不會處理該請求。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("400BadRequest")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response400Provider))]
    public IActionResult ResponseStatus400()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40000,
            Message = "由於明顯的客戶端錯誤（例如，格式錯誤的請求語法，太大的大小，無效的請求訊息或欺騙性路由請求），伺服器不能或不會處理該請求。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status400BadRequest};
        return result;
    }

    /// <summary>
    ///     類似於403 Forbidden，401語意即「未認證」，即使用者沒有必要的憑據。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("401Unauthorized")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status401Unauthorized, typeof(Response401Provider))]
    public IActionResult ResponseStatus401()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40100,
            Message =
                "類似於403 Forbidden，401語意即「未認證」，即使用者沒有必要的憑據。" +
                "該狀態碼表示當前請求需要使用者驗證。" +
                "該回應必須包含一個適用於被請求資源的WWW-Authenticate資訊頭用以詢問使用者資訊。" +
                "客戶端可以重複提交一個包含恰當的Authorization頭資訊的請求。" +
                "如果當前請求已經包含了Authorization憑證，那麼401回應代表著伺服器驗證已經拒絕了那些憑證。" +
                "如果401回應包含了與前一個回應相同的身分驗證詢問，且瀏覽器已經至少嘗試了一次驗證，那麼瀏覽器應當向使用者展示回應中包含的實體資訊，因為這個實體資訊中可能包含了相關診斷資訊。" +
                "注意：當網站（通常是網站域名）禁止IP位址時，有些網站狀態碼顯示的401，表示該特定位址被拒絕存取網站。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status401Unauthorized};
        return result;
    }

    /// <summary>
    ///     該狀態碼是為了將來可能的需求而預留的。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("402PaymentRequired")]
    [SwaggerResponse(StatusCodes.Status402PaymentRequired, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status402PaymentRequired, typeof(Response402Provider))]
    public IActionResult ResponseStatus402()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40200,
            Message =
                "該狀態碼是為了將來可能的需求而預留的。" +
                "該狀態碼最初的意圖可能被用作某種形式的數字現金或線上支付方案的一部分，但幾乎沒有哪家服務商使用，而且這個狀態碼通常不被使用。" +
                "如果特定開發人員已超過請求的每日限制，Google Developers API會使用此狀態碼。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status402PaymentRequired};
        return result;
    }

    /// <summary>
    ///     伺服器已經理解請求，但是拒絕執行它。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("403Forbidden")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status403Forbidden, typeof(Response403Provider))]
    public IActionResult ResponseStatus403()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40300,
            Message =
                "伺服器已經理解請求，但是拒絕執行它。" +
                "與401回應不同的是，身分驗證並不能提供任何幫助，而且這個請求也不應該被重複提交。" +
                "如果這不是一個HEAD請求，而且伺服器希望能夠講清楚為何請求不能被執行，那麼就應該在實體內描述拒絕的原因。" +
                "當然伺服器也可以返回一個404回應，假如它不希望讓客戶端獲得任何資訊。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status403Forbidden};
        return result;
    }

    /// <summary>
    ///     請求失敗，請求所希望得到的資源未被在伺服器上發現，但允許使用者的後續請求。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("404NotFound")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(Response404Provider))]
    public IActionResult ResponseStatus404(Test t)
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40400,
            Message =
                "請求失敗，請求所希望得到的資源未被在伺服器上發現，但允許使用者的後續請求。" +
                "沒有資訊能夠告訴使用者這個狀況到底是暫時的還是永久的。" +
                "假如伺服器知道情況的話，應當使用410狀態碼來告知舊資源因為某些內部的組態機制問題，已經永久的不可用，而且沒有任何可以跳轉的位址。404這個狀態碼被廣泛應用於當伺服器不想揭示到底為何請求被拒絕或者沒有其他適合的回應可用的情況下。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status404NotFound};
        return result;
    }

    /// <summary>
    ///     請求行中指定的請求方法不能被用於請求相應的資源。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("405MethodNotAllowed")]
    [SwaggerResponse(StatusCodes.Status405MethodNotAllowed, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status405MethodNotAllowed, typeof(Response405Provider))]
    public IActionResult ResponseStatus405()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40500,
            Message =
                "請求行中指定的請求方法不能被用於請求相應的資源。" +
                "該回應必須返回一個Allow頭資訊用以表示出當前資源能夠接受的請求方法的列表。" +
                "例如，需要通過POST呈現資料的表單上的GET請求，或唯讀資源上的PUT請求。" +
                "鑑於PUT，DELETE方法會對伺服器上的資源進行寫操作，因而絕大部分的網頁伺服器都不支援或者在預設組態下不允許上述請求方法，對於此類請求均會返回405錯誤。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status405MethodNotAllowed};
        return result;
    }

    /// <summary>
    ///     請求的資源的內容特性無法滿足請求頭中的條件，因而無法生成回應實體，該請求不可接受。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("406NotAcceptable")]
    [SwaggerResponse(StatusCodes.Status406NotAcceptable, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status406NotAcceptable, typeof(Response406Provider))]
    public IActionResult ResponseStatus406()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40600,
            Message =
                "請求的資源的內容特性無法滿足請求頭中的條件，因而無法生成回應實體，該請求不可接受。" +
                "除非這是一個HEAD請求，否則該回應就應當返回一個包含可以讓使用者或者瀏覽器從中選擇最合適的實體特性以及網址列表的實體。" +
                "實體的格式由Content-Type頭中定義的媒體類型決定。瀏覽器可以根據格式及自身能力自行作出最佳選擇。" +
                "但是，規範中並沒有定義任何作出此類自動選擇的標準。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status406NotAcceptable};
        return result;
    }

    /// <summary>
    ///     與401回應類似，只不過客戶端必須在代理伺服器上進行身分驗證。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("407ProxyAuthenticationRequired")]
    [SwaggerResponse(StatusCodes.Status407ProxyAuthenticationRequired, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status407ProxyAuthenticationRequired, typeof(Response407Provider))]
    public IActionResult ResponseStatus407()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40700,
            Message =
                "與401回應類似，只不過客戶端必須在代理伺服器上進行身分驗證。" +
                "代理伺服器必須返回一個Proxy-Authenticate用以進行身分詢問。" +
                "客戶端可以返回一個Proxy-Authorization資訊頭用以驗證。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status407ProxyAuthenticationRequired};
        return result;
    }

    /// <summary>
    ///     請求逾時。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("408RequestTimeout")]
    [SwaggerResponse(StatusCodes.Status408RequestTimeout, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status408RequestTimeout, typeof(Response408Provider))]
    public IActionResult ResponseStatus408()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40800,
            Message =
                "請求逾時。" +
                "根據HTTP規範，客戶端沒有在伺服器預備等待的時間內完成一個請求的傳送，客戶端可以隨時再次提交這一請求而無需進行任何更改。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status408RequestTimeout};
        return result;
    }

    /// <summary>
    ///     表示因為請求存在衝突無法處理該請求，例如多個同步更新之間的編輯衝突。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("409Conflict")]
    [SwaggerResponse(StatusCodes.Status409Conflict, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(Response409Provider))]
    public IActionResult ResponseStatus409()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 40900,
            Message =
                "表示因為請求存在衝突無法處理該請求，例如多個同步更新之間的編輯衝突。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status409Conflict};
        return result;
    }
    /// <summary>
    ///     表示因為請求存在衝突無法處理該請求，例如多個同步更新之間的編輯衝突。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("410Gone")]
    [SwaggerResponse(StatusCodes.Status410Gone, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status410Gone, typeof(Response410Provider))]
    public IActionResult ResponseStatus410()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 41000,
            Message =
                "表示所請求的資源不再可用。" +
                "當資源被有意地刪除並且資源應被清除時，應該使用這個。在收到410狀態碼後，使用者應停止再次請求資源。" +
                "但大多數伺服器端不會使用此狀態碼，而是直接使用404狀態碼。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status410Gone};
        return result;
    }
    
    
    /// <summary>
    ///     表示因為請求存在衝突無法處理該請求，例如多個同步更新之間的編輯衝突。
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("410Gone")]
    [SwaggerResponse(StatusCodes.Status411LengthRequired, "成功", typeof(Result<string>))]
    [SwaggerResponseExample(StatusCodes.Status411LengthRequired, typeof(Response410Provider))]
    public IActionResult ResponseStatus411()
    {
        var data = new Result<string>
        {
            Success = true,
            Code = 41100,
            Message =
                "表示所請求的資源不再可用。" +
                "當資源被有意地刪除並且資源應被清除時，應該使用這個。在收到410狀態碼後，使用者應停止再次請求資源。" +
                "但大多數伺服器端不會使用此狀態碼，而是直接使用404狀態碼。"
        };

        var result = new ObjectResult(data) {StatusCode = StatusCodes.Status411LengthRequired};
        return result;
    }
}