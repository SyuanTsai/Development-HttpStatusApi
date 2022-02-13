using BasicDomain.Model;
using Swashbuckle.AspNetCore.Filters;

namespace HttpStatusApi.Controllers;

public partial class HttpStatus200Controller
{
    public class Response200Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20000,
                Message =
                    "請求已成功，請求所希望的回應頭或資料體將隨此回應返回。" +
                    "實際的回應將取決於所使用的請求方法。" +
                    "在GET請求中，回應將包含與請求的資源相對應的實體。" +
                    "在POST請求中，回應將包含描述或操作結果的實體。"
            };
            return model;
        }
    }

    public class Response201Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20100,
                Message =
                    "請求已經被實現，而且有一個新的資源已經依據請求的需要而建立，且其URI已經隨Location頭資訊返回。" +
                    "假如需要的資源無法及時建立的話，應當返回202 Accepted。"
            };
            return model;
        }
    }

    public class Response202Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20200,
                Message =
                    "伺服器已接受請求，但尚未處理。" +
                    "最終該請求可能會也可能不會被執行，並且可能在處理發生時被禁止。"
            };
            return model;
        }
    }

    public class Response203Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20300,
                Message =
                    "服器是一個轉換代理伺服器（transforming proxy，例如網路加速器），以200 OK狀態碼為起源，但回應了原始回應的修改版本。"
            };
            return model;
        }
    }

    public class Response204Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20400,
                Message =
                    "伺服器成功處理了請求，沒有返回任何內容。"
            };
            return model;
        }
    }

    public class Response205Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20500,
                Message =
                    "伺服器成功處理了請求，但沒有返回任何內容。" +
                    "與204回應不同，此回應要求請求者重設文件視圖。"
            };

            return model;
        }
    }

    public class Response206Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20600,
                Message =
                    "伺服器已經成功處理了部分GET請求。" +
                    "類似於FlashGet或者迅雷這類的HTTP下載工具都是使用此類回應實現斷點續傳或者將一個大文件分解為多個下載段同時下載。"
            };
            return model;
        }
    }

    public class Response207Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20700,
                Message =
                    "代表之後的訊息體將是一個XML訊息，並且可能依照之前子請求數量的不同，包含一系列獨立的回應代碼。"
            };
            return model;
        }
    }

    public class Response208Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 20800,
                Message =
                    "DAV繫結的成員已經在（多狀態）回應之前的部分被列舉，且未被再次包含。"
            };
            return model;
        }
    }

    public class Response226Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 22600,
                Message =
                    "伺服器已經滿足了對資源的請求，對實體請求的一個或多個實體操作的結果表示。"
            };
            return model;
        }
    }
}