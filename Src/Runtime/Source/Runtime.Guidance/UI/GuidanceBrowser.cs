﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using NuPattern.Reflection;

namespace NuPattern.Runtime.Guidance.UI
{
    internal class GuidanceBrowser : UserControl
    {
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register(Reflector<GuidanceBrowser>.GetPropertyName(x => x.Source), typeof(Uri), typeof(GuidanceBrowser), new UIPropertyMetadata(OnSourceChanged));
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(Reflector<GuidanceBrowser>.GetPropertyName(x => x.Command), typeof(System.Windows.Input.ICommand), typeof(GuidanceBrowser));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(Reflector<GuidanceBrowser>.GetPropertyName(x => x.CommandParameter), typeof(object), typeof(GuidanceBrowser));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "It is immutable")]
        public static readonly DependencyPropertyKey CurrentLinkPropertyKey =
            DependencyProperty.RegisterReadOnly(Reflector<GuidanceBrowser>.GetPropertyName(x => x.CurrentLink), typeof(Uri), typeof(GuidanceBrowser), new UIPropertyMetadata(null));

        private WebBrowser webBrowser;

        public GuidanceBrowser()
        {
            this.webBrowser = new WebBrowser();
            this.webBrowser.Navigating += this.OnNavigating;

            this.Content = this.webBrowser;
            GuidanceCallContext.Current.GuidanceBrowserControl = this;
        }

        public System.Windows.Input.ICommand Command
        {
            get { return (System.Windows.Input.ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        public Uri CurrentLink
        {
            get { return (Uri)this.GetValue(CurrentLinkPropertyKey.DependencyProperty); }
            set { this.SetValue(CurrentLinkPropertyKey, value); }
        }

        public Uri Source
        {
            get { return (Uri)this.GetValue(SourceProperty); }
            set { this.SetValue(SourceProperty, value); }
        }

        public Uri HREF
        {
            set { this.webBrowser.Navigate(value); }
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (GuidanceBrowser)d;
            control.webBrowser.Source = (Uri)e.NewValue;
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            this.CurrentLink = e.Uri;
            if (this.Source != e.Uri && this.Command != null)
            {
                e.Cancel = true;

                // Not sure how this could ever happen, since the value is supposed to be set in the
                // constructor of this class, but perhaps Current is being re-evaluated somewhere?
                //
                // Anyway, we must make sure this is set before the call to Execute
                //
                if (GuidanceCallContext.Current != null &&
                    GuidanceCallContext.Current.GuidanceBrowserControl == null)
                    GuidanceCallContext.Current.GuidanceBrowserControl = this;

                this.Command.Execute(this.CommandParameter);
            }

        }

        //private void webBrowser_Navigated(object sender, NavigationEventArgs e)
        //{
        //    var document = (dynamic)this.webBrowser.Document;
        //    var links = document.Links;

        //    foreach (var link in links)
        //    {
        //        link.onclick += new EventHandler(this.ClickLink2);
        //    }
        //}

        //private void ClickLink2(object sender, EventArgs e)
        //{
        //}
    }
}