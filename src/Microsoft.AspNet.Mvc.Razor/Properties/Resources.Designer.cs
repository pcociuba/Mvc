// <auto-generated />
namespace Microsoft.AspNet.Mvc.Razor
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Resources
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.AspNet.Mvc.Razor.Resources", typeof(Resources).GetTypeInfo().Assembly);

        /// <summary>
        /// Value cannot be null or empty.
        /// </summary>
        internal static string ArgumentCannotBeNullOrEmpty
        {
            get { return GetString("ArgumentCannotBeNullOrEmpty"); }
        }

        /// <summary>
        /// Value cannot be null or empty.
        /// </summary>
        internal static string FormatArgumentCannotBeNullOrEmpty()
        {
            return GetString("ArgumentCannotBeNullOrEmpty");
        }

        /// <summary>
        /// Error compiling page at '{0}'.
        /// </summary>
        internal static string CompilationFailed
        {
            get { return GetString("CompilationFailed"); }
        }

        /// <summary>
        /// Error compiling page at '{0}'.
        /// </summary>
        internal static string FormatCompilationFailed(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("CompilationFailed"), p0);
        }

        /// <summary>
        /// '{0}' cannot be invoked when a Layout page is set to be executed.
        /// </summary>
        internal static string FlushPointCannotBeInvoked
        {
            get { return GetString("FlushPointCannotBeInvoked"); }
        }

        /// <summary>
        /// '{0}' cannot be invoked when a Layout page is set to be executed.
        /// </summary>
        internal static string FormatFlushPointCannotBeInvoked(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("FlushPointCannotBeInvoked"), p0);
        }

        /// <summary>
        /// The {0} returned by '{1}' must be an instance of '{2}'.
        /// </summary>
        internal static string Instrumentation_WriterMustBeBufferedTextWriter
        {
            get { return GetString("Instrumentation_WriterMustBeBufferedTextWriter"); }
        }

        /// <summary>
        /// The {0} returned by '{1}' must be an instance of '{2}'.
        /// </summary>
        internal static string FormatInstrumentation_WriterMustBeBufferedTextWriter(object p0, object p1, object p2)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("Instrumentation_WriterMustBeBufferedTextWriter"), p0, p1, p2);
        }

        /// <summary>
        /// The layout view '{0}' could not be located. The following locations were searched:{1}
        /// </summary>
        internal static string LayoutCannotBeLocated
        {
            get { return GetString("LayoutCannotBeLocated"); }
        }

        /// <summary>
        /// The layout view '{0}' could not be located. The following locations were searched:{1}
        /// </summary>
        internal static string FormatLayoutCannotBeLocated(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("LayoutCannotBeLocated"), p0, p1);
        }

        /// <summary>
        /// A layout page cannot be rendered after '{0}' has been invoked.
        /// </summary>
        internal static string LayoutCannotBeRendered
        {
            get { return GetString("LayoutCannotBeRendered"); }
        }

        /// <summary>
        /// A layout page cannot be rendered after '{0}' has been invoked.
        /// </summary>
        internal static string FormatLayoutCannotBeRendered(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("LayoutCannotBeRendered"), p0);
        }

        /// <summary>
        /// The 'inherits' keyword is not allowed when a '{0}' keyword is used.
        /// </summary>
        internal static string MvcRazorCodeParser_CannotHaveModelAndInheritsKeyword
        {
            get { return GetString("MvcRazorCodeParser_CannotHaveModelAndInheritsKeyword"); }
        }

        /// <summary>
        /// The 'inherits' keyword is not allowed when a '{0}' keyword is used.
        /// </summary>
        internal static string FormatMvcRazorCodeParser_CannotHaveModelAndInheritsKeyword(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MvcRazorCodeParser_CannotHaveModelAndInheritsKeyword"), p0);
        }

        /// <summary>
        /// The '{0}' keyword must be followed by a type name on the same line.
        /// </summary>
        internal static string MvcRazorCodeParser_ModelKeywordMustBeFollowedByTypeName
        {
            get { return GetString("MvcRazorCodeParser_ModelKeywordMustBeFollowedByTypeName"); }
        }

        /// <summary>
        /// The '{0}' keyword must be followed by a type name on the same line.
        /// </summary>
        internal static string FormatMvcRazorCodeParser_ModelKeywordMustBeFollowedByTypeName(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MvcRazorCodeParser_ModelKeywordMustBeFollowedByTypeName"), p0);
        }

        /// <summary>
        /// Only one '{0}' statement is allowed in a file.
        /// </summary>
        internal static string MvcRazorCodeParser_OnlyOneModelStatementIsAllowed
        {
            get { return GetString("MvcRazorCodeParser_OnlyOneModelStatementIsAllowed"); }
        }

        /// <summary>
        /// Only one '{0}' statement is allowed in a file.
        /// </summary>
        internal static string FormatMvcRazorCodeParser_OnlyOneModelStatementIsAllowed(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("MvcRazorCodeParser_OnlyOneModelStatementIsAllowed"), p0);
        }

        /// <summary>
        /// There is no active writing scope to end.
        /// </summary>
        internal static string RazorPage_ThereIsNoActiveWritingScopeToEnd
        {
            get { return GetString("RazorPage_ThereIsNoActiveWritingScopeToEnd"); }
        }

        /// <summary>
        /// There is no active writing scope to end.
        /// </summary>
        internal static string FormatRazorPage_ThereIsNoActiveWritingScopeToEnd()
        {
            return GetString("RazorPage_ThereIsNoActiveWritingScopeToEnd");
        }

        /// <summary>
        /// You cannot flush while inside a writing scope.
        /// </summary>
        internal static string RazorPage_YouCannotFlushWhileInAWritingScope
        {
            get { return GetString("RazorPage_YouCannotFlushWhileInAWritingScope"); }
        }

        /// <summary>
        /// You cannot flush while inside a writing scope.
        /// </summary>
        internal static string FormatRazorPage_YouCannotFlushWhileInAWritingScope()
        {
            return GetString("RazorPage_YouCannotFlushWhileInAWritingScope");
        }

        /// <summary>
        /// The {0} was unable to provide metadata for expression '{1}'.
        /// </summary>
        internal static string RazorPage_NullModelMetadata
        {
            get { return GetString("RazorPage_NullModelMetadata"); }
        }

        /// <summary>
        /// The {0} was unable to provide metadata for expression '{1}'.
        /// </summary>
        internal static string FormatRazorPage_NullModelMetadata(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RazorPage_NullModelMetadata"), p0, p1);
        }

        /// <summary>
        /// {0} can only be called from a layout page.
        /// </summary>
        internal static string RazorPage_MethodCannotBeCalled
        {
            get { return GetString("RazorPage_MethodCannotBeCalled"); }
        }

        /// <summary>
        /// {0} can only be called from a layout page.
        /// </summary>
        internal static string FormatRazorPage_MethodCannotBeCalled(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RazorPage_MethodCannotBeCalled"), p0);
        }

        /// <summary>
        /// {0} must be called from a layout page.
        /// </summary>
        internal static string RenderBodyNotCalled
        {
            get { return GetString("RenderBodyNotCalled"); }
        }

        /// <summary>
        /// {0} must be called from a layout page.
        /// </summary>
        internal static string FormatRenderBodyNotCalled(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RenderBodyNotCalled"), p0);
        }

        /// <summary>
        /// Section '{0}' is already defined.
        /// </summary>
        internal static string SectionAlreadyDefined
        {
            get { return GetString("SectionAlreadyDefined"); }
        }

        /// <summary>
        /// Section '{0}' is already defined.
        /// </summary>
        internal static string FormatSectionAlreadyDefined(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SectionAlreadyDefined"), p0);
        }

        /// <summary>
        /// The section named '{0}' has already been rendered.
        /// </summary>
        internal static string SectionAlreadyRendered
        {
            get { return GetString("SectionAlreadyRendered"); }
        }

        /// <summary>
        /// The section named '{0}' has already been rendered.
        /// </summary>
        internal static string FormatSectionAlreadyRendered(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SectionAlreadyRendered"), p0);
        }

        /// <summary>
        /// Section '{0}' is not defined.
        /// </summary>
        internal static string SectionNotDefined
        {
            get { return GetString("SectionNotDefined"); }
        }

        /// <summary>
        /// Section '{0}' is not defined.
        /// </summary>
        internal static string FormatSectionNotDefined(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SectionNotDefined"), p0);
        }

        /// <summary>
        /// The following sections have been defined but have not been rendered: '{0}'.
        /// </summary>
        internal static string SectionsNotRendered
        {
            get { return GetString("SectionsNotRendered"); }
        }

        /// <summary>
        /// The following sections have been defined but have not been rendered: '{0}'.
        /// </summary>
        internal static string FormatSectionsNotRendered(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("SectionsNotRendered"), p0);
        }

        /// <summary>
        /// View of type '{0}' cannot be activated by '{1}'.
        /// </summary>
        internal static string ViewCannotBeActivated
        {
            get { return GetString("ViewCannotBeActivated"); }
        }

        /// <summary>
        /// View of type '{0}' cannot be activated by '{1}'.
        /// </summary>
        internal static string FormatViewCannotBeActivated(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ViewCannotBeActivated"), p0, p1);
        }

        /// <summary>
        /// '{0} must be set to access '{1}'.
        /// </summary>
        internal static string ViewContextMustBeSet
        {
            get { return GetString("ViewContextMustBeSet"); }
        }

        /// <summary>
        /// '{0} must be set to access '{1}'.
        /// </summary>
        internal static string FormatViewContextMustBeSet(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ViewContextMustBeSet"), p0, p1);
        }

        /// <summary>
        /// '{0}' must be a {1} that is generated as result of the call to '{2}'.
        /// </summary>
        internal static string ViewLocationCache_KeyMustBeString
        {
            get { return GetString("ViewLocationCache_KeyMustBeString"); }
        }

        /// <summary>
        /// '{0}' must be a {1} that is generated as result of the call to '{2}'.
        /// </summary>
        internal static string FormatViewLocationCache_KeyMustBeString(object p0, object p1, object p2)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ViewLocationCache_KeyMustBeString"), p0, p1, p2);
        }

        /// <summary>
        /// The '{0}' method must be called before '{1}' can be invoked.
        /// </summary>
        internal static string ViewMustBeContextualized
        {
            get { return GetString("ViewMustBeContextualized"); }
        }

        /// <summary>
        /// The '{0}' method must be called before '{1}' can be invoked.
        /// </summary>
        internal static string FormatViewMustBeContextualized(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ViewMustBeContextualized"), p0, p1);
        }

        /// <summary>
        /// Unsupported hash algorithm.
        /// </summary>
        internal static string RazorHash_UnsupportedHashAlgorithm
        {
            get { return GetString("RazorHash_UnsupportedHashAlgorithm"); }
        }

        /// <summary>
        /// Unsupported hash algorithm.
        /// </summary>
        internal static string FormatRazorHash_UnsupportedHashAlgorithm()
        {
            return GetString("RazorHash_UnsupportedHashAlgorithm");
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
