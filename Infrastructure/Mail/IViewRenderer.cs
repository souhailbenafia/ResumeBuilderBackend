using System.Threading.Tasks;

namespace Infrastructure.Mail { 
    /// <summary>
    /// View renderer.
    /// </summary>
public interface IViewRenderer
    {
        /// <summary>
        /// Compiles a razor view.
        /// </summary>
        /// 
        /// <param name="viewName">View name.</param>
        /// <param name="model">View model.</param>        
        Task<string> RenderAsync(string viewName, object model);
    }
}
