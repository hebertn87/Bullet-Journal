﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuJoApp.Xam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainPageVM vm) : this()
        {
            BindingContext = vm;
        }
    }
}