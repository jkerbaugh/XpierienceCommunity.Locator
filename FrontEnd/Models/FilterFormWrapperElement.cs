using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace XperienceCommunity.Locator
{
    public class FilterFormWrapperElement : IDisposable
    {
        private readonly ViewContext viewContext;
        private readonly LocatorFilterComponent component;

        private bool disposed;

        /// <summary>
        /// Initializes a new instance of <see cref="MvcForm"/>.
        /// </summary>
        /// <param name="viewContext">The <see cref="ViewContext"/>.</param>
        /// <param name="htmlEncoder">The <see cref="HtmlEncoder"/>.</param>
        public FilterFormWrapperElement(ViewContext viewContext, LocatorFilterComponent component)
        {
            this.viewContext = viewContext ?? throw new ArgumentNullException(nameof(viewContext));
            this.component = component ?? throw new ArgumentNullException(nameof(component));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;

                var tagBuilder = new TagBuilder(component.RenderingConfiguration.WrapperElement)
                {
                    TagRenderMode = TagRenderMode.EndTag
                };

                tagBuilder.WriteTo(viewContext.Writer, HtmlEncoder.Default);
            }
        }
    }
}
