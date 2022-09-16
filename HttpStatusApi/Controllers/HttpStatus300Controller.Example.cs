using BasicDomain.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace HttpStatusApi.Controllers;

public partial class HttpStatus300Controller
{
    public class Response300Provider : IExamplesProvider<Result<string>>
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
    public class Response301Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30100,
                Message =
                    "被請求的資源已永久移動到新位置，並且將來任何對此資源的參照都應該使用本回應返回的若干個URI之一。" +
                    "如果可能，擁有連結編輯功能的客戶端應當自動把請求的位址修改為從伺服器回饋回來的位址。" +
                    "除非額外指定，否則這個回應也是可快取的。" +
                    "新的永久性的URI應當在回應的Location域中返回。" +
                    "除非這是一個HEAD請求，否則回應的實體中應當包含指向新的URI的超連結及簡短說明。" +
                    "如果這不是一個GET或者HEAD請求，那麼瀏覽器禁止自動進行重新導向，除非得到使用者的確認，因為請求的條件可能因此發生變化。" +
                    "注意：對於某些使用HTTP/1.0協定的瀏覽器，當它們傳送的POST請求得到了一個301回應的話，接下來的重新導向請求將會變成GET方式。"
            };
            return model;
        }
    }
    public class Response302Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30200,
                Message =
                    "要求客戶端執行臨時重新導向（原始描述短語為「Moved Temporarily」）。" +
                    "由於這樣的重新導向是臨時的，客戶端應當繼續向原有位址傳送以後的請求。只有在Cache-Control或Expires中進行了指定的情況下，這個回應才是可快取的。" +
                    "新的臨時性的URI應當在回應的Location域中返回。除非這是一個HEAD請求，否則回應的實體中應當包含指向新的URI的超連結及簡短說明。" +
                    "如果這不是一個GET或者HEAD請求，那麼瀏覽器禁止自動進行重新導向，除非得到使用者的確認，因為請求的條件可能因此發生變化。" +
                    "注意：雖然RFC 1945和RFC 2068規範不允許客戶端在重新導向時改變請求的方法，但是很多現存的瀏覽器將302回應視作為303回應，並且使用GET方式存取在Location中規定的URI，而無視原先請求的方法。" +
                    "因此狀態碼303和307被添加了進來，用以明確伺服器期待客戶端進行何種反應。"
            };
            
            return model;
        }
    }
    public class Response303Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30300,
                Message =
                    "對應當前請求的回應可以在另一個URI上被找到，當回應於POST（或PUT / DELETE）接收到回應時，客戶端應該假定伺服器已經收到資料，並且應該使用單獨的GET訊息發出重新導向。" +
                    "這個方法的存在主要是為了允許由指令碼啟用的POST請求輸出重新導向到一個新的資源。這個新的URI不是原始資源的替代參照。" +
                    "同時，303回應禁止被快取。當然，第二個請求（重新導向）可能被快取。" +
                    "新的URI應當在回應的Location域中返回。除非這是一個HEAD請求，否則回應的實體中應當包含指向新的URI的超連結及簡短說明。" +
                    "注意：許多HTTP/1.1版以前的瀏覽器不能正確理解303狀態。如果需要考慮與這些瀏覽器之間的互動，302狀態碼應該可以勝任，因為大多數的瀏覽器處理302回應時的方式恰恰就是上述規範要求客戶端處理303回應時應當做的。"
            };

            
            return model;
        }
    }
    public class Response304Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30400,
                Message =
                    "表示資源在由請求頭中的If-Modified-Since或If-None-Match參數指定的這一版本之後，未曾被修改。" +
                    "在這種情況下，由於客戶端仍然具有以前下載的副本，因此不需要重新傳輸資源。"
            };
            
            return model;
        }
    }
    public class Response305Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30500,
                Message =
                    "被請求的資源必須通過指定的代理才能被存取。" +
                    "Location域中將給出指定的代理所在的URI資訊，接收者需要重複傳送一個單獨的請求，通過這個代理才能存取相應資源。" +
                    "只有原始伺服器才能建立305回應。" +
                    "許多HTTP客戶端（像是Mozilla和Internet Explorer）都沒有正確處理這種狀態代碼的回應，主要是出於安全考慮。" +
                    "注意：RFC 2068中沒有明確305回應是為了重新導向一個單獨的請求，而且只能被原始伺服器建立。忽視這些限制可能導致嚴重的安全後果。"
            };

            return model;
        }
    }
    public class Response306Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30600,
                Message =
                    "在最新版的規範中，306狀態碼已經不再被使用。最初是指「後續請求應使用指定的代理」。"
            };

            return model;
        }
    }
    public class Response307Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30700,
                Message =
                    "在這種情況下，請求應該與另一個URI重複，但後續的請求應仍使用原始的URI。 與302相反，當重新發出原始請求時，不允許更改請求方法。" +
                    "例如，應該使用另一個POST請求來重複POST請求。"
            };

            return model;
        }
    }
    public class Response308Provider : IExamplesProvider<Result<string>>
    {
        public Result<string> GetExamples()
        {
            var model = new Result<string>
            {
                Success = true,
                Code = 30800,
                Message =
                    "求和所有將來的請求應該使用另一個URI重複。 307和308重複302和301的行為，但不允許HTTP方法更改。" +
                    "例如，將表單提交給永久重新導向的資源可能會順利進行。"
            };

            return model;
        }
    }
}