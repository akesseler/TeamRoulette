/*
 * MIT License
 * 
 * Copyright (c) 2023 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Plexdata.TeamRoulette.Dialogs
{
    partial class AboutDialog : Form
    {
        #region Construction

        public AboutDialog()
            : base()
        {
            this.InitializeComponent();

            AboutDialogInfo info = AppDomain.CurrentDomain.GetCurrentAssemblyInformation();

            this.Text += info.Title;
            this.lblProduct.Text = info.Product;
            this.lblVersion.Text = $"{this.lblVersion.Text} {info.Version}";
            this.lblCopyright.Text = info.Copyright;
            this.txtDescription.Text = info.Description;
        }

        #endregion

        #region Event Handlers

        private void OnLogoClicked(Object sender, EventArgs args)
        {
            Process.Start("http://www.plexdata.de/");
        }

        private void OnCloseButtonClicked(Object sender, EventArgs args)
        {
            this.Close();
        }

        #endregion
    }

    internal static class AboutDialogHelper
    {
        #region Public Methods

        public static AboutDialogInfo GetCurrentAssemblyInformation(this AppDomain domain)
        {
            try
            {
                return domain.GetAssemblyInformation(Assembly.GetExecutingAssembly().FullName, false).First();
            }
            catch { }

            return new AboutDialogInfo();
        }

        public static IEnumerable<AboutDialogInfo> GetAssemblyInformation(this AppDomain domain)
        {
            return domain.GetAssemblyInformation(Assembly.GetExecutingAssembly().FullName, true);
        }

        public static IEnumerable<AboutDialogInfo> GetAssemblyInformation(this AppDomain domain, String affected)
        {
            return domain.GetAssemblyInformation(affected, false);
        }

        public static IEnumerable<AboutDialogInfo> GetAssemblyInformation(this AppDomain domain, String affected, Boolean excluded)
        {
            if (domain == null)
            {
                return Enumerable.Empty<AboutDialogInfo>();
            }

            try
            {
                IEnumerable<Assembly> assemblies = Enumerable.Empty<Assembly>();

                if (String.IsNullOrWhiteSpace(affected))
                {
                    assemblies = domain.GetAssemblies();
                }
                else if (excluded)
                {
                    assemblies = domain.GetAssemblies().Where(x => !x.FullName.StartsWith(affected));
                }
                else
                {
                    assemblies = domain.GetAssemblies().Where(x => x.FullName.StartsWith(affected));
                }

                List<AboutDialogInfo> result = new List<AboutDialogInfo>();

                foreach (Assembly current in assemblies)
                {
                    result.Add(new AboutDialogInfo(current));
                }

                return result;
            }
            catch { }

            return Enumerable.Empty<AboutDialogInfo>();
        }

        public static String GetTitle(this Assembly assembly)
        {
            try
            {
                Type type = typeof(AssemblyTitleAttribute);

                if (AssemblyTitleAttribute.IsDefined(assembly, type))
                {
                    AssemblyTitleAttribute attribute = (AssemblyTitleAttribute)AssemblyTitleAttribute.GetCustomAttribute(assembly, type);
                    return attribute.Title;
                }
            }
            catch { }

            return String.Empty;
        }

        public static String GetCompany(this Assembly assembly)
        {
            try
            {
                Type type = typeof(AssemblyCompanyAttribute);
                if (AssemblyCompanyAttribute.IsDefined(assembly, type))
                {
                    AssemblyCompanyAttribute attribute = (AssemblyCompanyAttribute)AssemblyCompanyAttribute.GetCustomAttribute(assembly, type);
                    return attribute.Company;
                }

            }
            catch { }

            return String.Empty;
        }

        public static String GetCopyright(this Assembly assembly)
        {
            try
            {
                Type type = typeof(AssemblyCopyrightAttribute);
                if (AssemblyCopyrightAttribute.IsDefined(assembly, type))
                {
                    AssemblyCopyrightAttribute attribute = (AssemblyCopyrightAttribute)AssemblyCopyrightAttribute.GetCustomAttribute(assembly, type);
                    return attribute.Copyright;
                }

            }
            catch { }

            return String.Empty;
        }

        public static String GetProduct(this Assembly assembly)
        {
            try
            {
                Type type = typeof(AssemblyProductAttribute);
                if (AssemblyProductAttribute.IsDefined(assembly, type))
                {
                    AssemblyProductAttribute attribute = (AssemblyProductAttribute)AssemblyProductAttribute.GetCustomAttribute(assembly, type);
                    return attribute.Product;
                }

            }
            catch { }

            return String.Empty;
        }

        public static String GetFileName(this Assembly assembly)
        {
            if (assembly == null)
            {
                return String.Empty;
            }

            try
            {
                return Path.GetFileName(assembly.Location);
            }
            catch { }

            return String.Empty;
        }

        public static String GetVersion(this Assembly assembly)
        {
            try
            {
                return assembly.GetName().Version.ToString();
            }
            catch { }

            return String.Empty;
        }

        public static String GetDescription(this Assembly assembly)
        {
            try
            {
                Type type = typeof(AssemblyDescriptionAttribute);

                if (AssemblyDescriptionAttribute.IsDefined(assembly, type))
                {
                    AssemblyDescriptionAttribute attribute = (AssemblyDescriptionAttribute)AssemblyDescriptionAttribute.GetCustomAttribute(assembly, type);
                    return attribute.Description;
                }
            }
            catch { }

            return String.Empty;
        }

        #endregion
    }

    internal class AboutDialogInfo
    {
        #region Construction

        public AboutDialogInfo()
            : base()
        {
        }

        public AboutDialogInfo(Assembly assembly)
            : this()
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            this.Title = assembly.GetTitle();
            this.Company = assembly.GetCompany();
            this.Copyright = assembly.GetCopyright();
            this.Product = assembly.GetProduct();
            this.FileName = assembly.GetFileName();
            this.Version = assembly.GetVersion();
            this.Description = assembly.GetDescription();
        }

        #endregion

        #region Public Properties

        public String Title { get; set; }

        public String Company { get; set; }

        public String Copyright { get; set; }

        public String Product { get; set; }

        public String FileName { get; set; }

        public String Version { get; set; }

        public String Description { get; set; }

        #endregion

        #region Public Methods

        public override String ToString()
        {
            const String separator = ", ";

            StringBuilder builder = new StringBuilder(128);

            if (!String.IsNullOrWhiteSpace(this.Title))
            {
                builder.Append($"{this.Title}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.Company))
            {
                builder.Append($"{this.Company}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.Copyright))
            {
                builder.Append($"{this.Copyright}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.Product))
            {
                builder.Append($"{this.Product}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.FileName))
            {
                builder.Append($"{this.FileName}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.Version))
            {
                builder.Append($"{this.Version}{separator}");
            }

            if (!String.IsNullOrWhiteSpace(this.Description))
            {
                builder.Append($"{this.Description}{separator}");
            }

            return builder.ToString().TrimEnd(separator.ToCharArray());
        }

        #endregion
    }
}
