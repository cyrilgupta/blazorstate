using Microsoft.JSInterop;


namespace BlazorState.Client
{
    public class JSStorage
    {
        public IJSRuntime _jsRuntime;
        public IJSRuntime JSRuntime
        {
            get
            {
                return _jsRuntime;
            }
        }

        public JSStorage(IJSRuntime js)
        {
            _jsRuntime = js;
        }

        public async Task Save(string name, string val)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", name, val);
        }

        public async Task<string> Read(string name)
        {
            string res = await JSRuntime.InvokeAsync<string>("localStorage.getItem", name);
            return res;
        }

        public async Task Delete(string name)
        {
            await JSRuntime.InvokeAsync<string>("localStorage.removeItem", name);
        }
    }
}
