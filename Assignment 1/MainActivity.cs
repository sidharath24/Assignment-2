using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Assignment_1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView PriceShowTv, QuantityShowTv, TotalShowTv, FinalPriceShow;
        Button TotalBtn;
        RadioButton rdb5, rdb10, rdb15;
        SeekBar PriceSeekBar, QuantitySeekBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            PriceShowTv = (TextView)FindViewById(Resource.Id.tvPriceShow);
            QuantityShowTv = (TextView)FindViewById(Resource.Id.TvQuantityShow);
            TotalShowTv = (TextView)FindViewById(Resource.Id.TvTotalShow);
            FinalPriceShow = (TextView)FindViewById(Resource.Id.TvFinalPriceShow);
            TotalBtn = (Button)FindViewById(Resource.Id.btnTotal);
            rdb5 = (RadioButton)FindViewById(Resource.Id.radioButton1);
            rdb10 = (RadioButton)FindViewById(Resource.Id.radioButton2);
            rdb15 = (RadioButton)FindViewById(Resource.Id.radioButton3);
            PriceSeekBar = (SeekBar)FindViewById(Resource.Id.sbPrice);
            QuantitySeekBar = (SeekBar)FindViewById(Resource.Id.SbQuantity);

            PriceSeekBar.ProgressChanged += delegate
            {
                PriceShowTv.Text = PriceSeekBar.Progress.ToString();
            };

            QuantitySeekBar.ProgressChanged += delegate
            {
                QuantityShowTv.Text = QuantitySeekBar.Progress.ToString();
            };
             

            TotalBtn.Click += delegate
            {
                if (rdb5.Checked)
                {
                    double total = (PriceSeekBar.Progress * QuantitySeekBar.Progress) - ((PriceSeekBar.Progress * QuantitySeekBar.Progress) * 0.05);
                    TotalShowTv.Text = total.ToString();
                    double FinalPrice = total + (0.13 * total);
                    FinalPriceShow.Text = FinalPrice.ToString();
                }

                if (rdb10.Checked)
                {
                    double total = (PriceSeekBar.Progress * QuantitySeekBar.Progress) - ((PriceSeekBar.Progress * QuantitySeekBar.Progress) * 0.10);
                    TotalShowTv.Text = total.ToString();
                    double FinalPrice = total + (0.13 * total);
                    FinalPriceShow.Text = FinalPrice.ToString();
                }

                if (rdb15.Checked)
                {
                    double total = (PriceSeekBar.Progress * QuantitySeekBar.Progress) - ((PriceSeekBar.Progress * QuantitySeekBar.Progress) * 0.15);
                    TotalShowTv.Text = total.ToString();
                    double FinalPrice = total + (0.13 * total);
                    FinalPriceShow.Text = FinalPrice.ToString();
                }

                

            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

