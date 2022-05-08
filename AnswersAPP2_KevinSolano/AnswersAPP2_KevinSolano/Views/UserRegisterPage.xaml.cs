using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnswersAPP2_KevinSolano.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswersAPP2_KevinSolano.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegisterPage : ContentPage
    {
        UserViewModel viewModel;
        public UserRegisterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            //TODO: se deben validar datos mínimos, estructura del email, complejidad de contraseña
            bool R = await viewModel.AddUser(TxtEmail.Text.Trim(),
                                             TxtName.Text.Trim(),
                                             TxtLastName.Text.Trim(),
                                             TxtPhone.Text.Trim(),
                                             TxtPass.Text.Trim(),
                                             TxtBackUpEmail.Text.Trim(),
                                             TxtJop.Text.Trim());

            if (R)
            {
                await DisplayAlert("!!!", "The user was added!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong!", "OK");
                //await Navigation.PopAsync();
            }



        }
    }
}