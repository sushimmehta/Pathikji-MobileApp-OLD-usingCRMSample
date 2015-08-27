﻿using Xamarin.Forms;
using XamarinCRM.Statics;
using System;

namespace XamarinCRM.Views.Sales
{
    public class LeadListHeaderView : ContentView
    {
        /// <summary>
        /// The command that will be executed when the new lead button is tapped
        /// </summary>
        readonly Command _NewLeadTappedCommand;

        public LeadListHeaderView(Command newLeadTappedCommand)
        {
            _NewLeadTappedCommand = newLeadTappedCommand;

            #region title label
            Label headerTitleLabel = new Label()
            {
                Text = TextResources.Leads_LeadListHeaderTitle.ToUpperInvariant(),
                TextColor = Palette._003,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center
            };
            #endregion

            #region new lead image "button"
            Image newLeadImage = new Image()
            {
                Source = new FileImageSource() { File = Device.OnPlatform("add_ios_gray", "add_android_gray", null) },
                Aspect = Aspect.AspectFit, 
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            newLeadImage.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = _NewLeadTappedCommand,
                    NumberOfTapsRequired = 1
                });
            #endregion

            #region absolutLayout
            AbsoluteLayout absolutLayout = new AbsoluteLayout();

            absolutLayout.Children.Add(
                headerTitleLabel, 
                new Rectangle(0, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), 
                AbsoluteLayoutFlags.PositionProportional);

            absolutLayout.Children.Add(
                newLeadImage, 
                new Rectangle(1, .5, AbsoluteLayout.AutoSize, .5), 
                AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional);
            #endregion

            #region setup contentView
            ContentView contentView = new ContentView()
            {
                Padding = new Thickness(10, 0), // give the content some padding on the left and right
                HeightRequest = Sizes.MediumRowHeight, // set the height of the content view
            };
            #endregion

            #region compose the view hierarchy
            contentView.Content = absolutLayout;
            #endregion

            Content = contentView;
        }
    }
}