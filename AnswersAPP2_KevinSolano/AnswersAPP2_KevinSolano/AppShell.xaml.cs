using AnswersAPP2_KevinSolano.ViewModels;
using AnswersAPP2_KevinSolano.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AnswersAPP2_KevinSolano
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
