using BasicDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace HttpStatusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class HttpStatus200Controller : ControllerBase
    {
        /// <summary>
        ///     請求已成功。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Ok")]
        [SwaggerResponse(StatusCodes.Status200OK, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(Response200Provider))]
        public IActionResult ResponseStatus200()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20000,
                Message =
                    "請求已成功，請求所希望的回應頭或資料體將隨此回應返回。" +
                    "實際的回應將取決於所使用的請求方法。" +
                    "在GET請求中，回應將包含與請求的資源相對應的實體。" +
                    "在POST請求中，回應將包含描述或操作結果的實體。",
            };
            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status200OK};
            return result;
        }

        /// <summary>
        ///     請求已經被實現，而且有一個新的資源已經依據請求的需要而建立，且其URI已經隨Location頭資訊返回。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Created")]
        [SwaggerResponse(StatusCodes.Status201Created, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(Response201Provider))]
        public IActionResult ResponseStatus201()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20100,
                Message =
                    "請求已經被實現，而且有一個新的資源已經依據請求的需要而建立，且其URI已經隨Location頭資訊返回。" +
                    "假如需要的資源無法及時建立的話，應當返回202 Accepted。",
            };

            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status201Created};
            return result;
        }

        /// <summary>
        ///     伺服器已接受請求，但尚未處理。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Accepted")]
        [SwaggerResponse(StatusCodes.Status202Accepted, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status202Accepted, typeof(Response202Provider))]
        public IActionResult ResponseStatus202()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20200,
                Message =
                    "伺服器已接受請求，但尚未處理。" +
                    "最終該請求可能會也可能不會被執行，並且可能在處理發生時被禁止。",
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status202Accepted};
            return result;
        }

        /// <summary>
        ///     服器是一個轉換代理伺服器（transforming proxy，例如網路加速器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Non-Authoritative")]
        [SwaggerResponse(StatusCodes.Status203NonAuthoritative, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status203NonAuthoritative, typeof(Response203Provider))]
        public IActionResult ResponseStatus203()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20300,
                Message =
                    "服器是一個轉換代理伺服器（transforming proxy，例如網路加速器），以200 OK狀態碼為起源，但回應了原始回應的修改版本。",
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status203NonAuthoritative};
            return result;
        }

        /// <summary>
        ///     伺服器成功處理了請求，沒有返回任何內容。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("NoContent")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status204NoContent, typeof(Response204Provider))]
        public IActionResult ResponseStatus204()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20400,
                Message =
                    "伺服器成功處理了請求，沒有返回任何內容。",
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status204NoContent};
            return result;
        }

        /// <summary>
        ///     伺服器成功處理了請求，但沒有返回任何內容。與204回應不同，此回應要求請求者重設文件視圖。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ResetContent")]
        [SwaggerResponse(StatusCodes.Status205ResetContent, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status205ResetContent, typeof(Response205Provider))]
        public IActionResult ResponseStatus205()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20500,
                Message =
                    "伺服器成功處理了請求，但沒有返回任何內容。" +
                    "與204回應不同，此回應要求請求者重設文件視圖。"
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status205ResetContent};
            return result;
        }

        /// <summary>
        ///     伺服器已經成功處理了部分GET請求。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PartialContent")]
        [SwaggerResponse(StatusCodes.Status206PartialContent, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status206PartialContent, typeof(Response206Provider))]
        public IActionResult ResponseStatus206()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20600,
                Message =
                    "伺服器已經成功處理了部分GET請求。" +
                    "類似於FlashGet或者迅雷這類的HTTP下載工具都是使用此類回應實現斷點續傳或者將一個大文件分解為多個下載段同時下載。"
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status206PartialContent};
            return result;
        }

        /// <summary>
        ///     代表之後的訊息體將是一個XML訊息，並且可能依照之前子請求數量的不同，包含一系列獨立的回應代碼。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Multi-Status")]
        [SwaggerResponse(StatusCodes.Status207MultiStatus, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status207MultiStatus, typeof(Response207Provider))]
        public IActionResult ResponseStatus207()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20700,
                Message =
                    "代表之後的訊息體將是一個XML訊息，並且可能依照之前子請求數量的不同，包含一系列獨立的回應代碼。"
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status207MultiStatus};
            return result;
        }

        /// <summary>
        ///     DAV繫結的成員已經在（多狀態）回應之前的部分被列舉，且未被再次包含。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AlreadyReported")]
        [SwaggerResponse(StatusCodes.Status208AlreadyReported, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status208AlreadyReported, typeof(Response208Provider))]
        public IActionResult ResponseStatus208()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 20800,
                Message =
                    "DAV繫結的成員已經在（多狀態）回應之前的部分被列舉，且未被再次包含。"
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status208AlreadyReported};
            return result;
        }

        /// <summary>
        ///     伺服器已經滿足了對資源的請求，對實體請求的一個或多個實體操作的結果表示。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("IMUsed")]
        [SwaggerResponse(StatusCodes.Status226IMUsed, "成功", typeof(Result<string>))]
        [SwaggerResponseExample(StatusCodes.Status226IMUsed, typeof(Response226Provider))]
        public IActionResult ResponseStatus226()
        {
            var data = new Result<string>
            {
                Success = true,
                Code = 22600,
                Message =
                    "伺服器已經滿足了對資源的請求，對實體請求的一個或多個實體操作的結果表示。"
            };


            var result = new ObjectResult(data) {StatusCode = StatusCodes.Status226IMUsed};
            return result;
        }
    }
}