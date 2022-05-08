using AnswersAPP2_KevinSolano.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnswersAPP2_KevinSolano.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}