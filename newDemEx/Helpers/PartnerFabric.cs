using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using newDemEx.BaseModel;
using newDemEx.Views;

namespace newDemEx.Helpers
{
    internal class PartnerFabric
    {
        private readonly sdvgEntities _db = new sdvgEntities().GetContext();
        private List<Partner> _partner;

        public PartnerFabric()
        {
            _partner = _db.Partner.ToList();
        }

        private decimal CalculateCost(Partner partner)
        {
            try
            {
                return _db.ProductInOrder.Where(p => p.Order.PartnerId == partner.Id).Select(p => p.Amount * p.Product.MinCost).Sum();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        private Border GetCard(Partner partner)
        {

            string partnerType = partner.Company.CompanyType.Name;
            string partnerName = partner.Company.Name;
            decimal cost = CalculateCost(partner);
            string buisnessAddress = partner.Company.BuisnessAddress;
            string phone = partner.Company.Phone;
            decimal rating = partner.Rating;

            Grid hat = new Grid
            {
                Children =
                {
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                        Children =
                        {
                            new TextBlock
                            {
                                Text = partnerType,
                            },
                            new TextBlock
                            {
                                Text = " | ",
                            },
                            new TextBlock
                            {
                                Text = partnerName,
                            },
                        }
                    },
                    new StackPanel
                    {
                        Orientation=Orientation.Horizontal,
                        HorizontalAlignment= System.Windows.HorizontalAlignment.Right,
                        Children =
                        {
                            new TextBlock
                            {
                                Text = $"{cost:C}"
                            }
                        }
                    }
                }
            };
            TextBlock buisnessAddressTextBlock = new TextBlock
            {
                Text = buisnessAddress,
            };
            TextBlock phoneTextBlock = new TextBlock
            {
                Text = phone,
            };
            TextBlock ratingTextBlock = new TextBlock
            {
                Text = $"Рейтинг: {rating}",
            };

            return new Border
            {
                Margin = new System.Windows.Thickness(80, 20, 80, 20),
                Padding = new System.Windows.Thickness(10),
                Style = (Style)Application.Current.FindResource("Card"),
                Child = new StackPanel
                {
                    Children =
                    {
                        hat,
                        buisnessAddressTextBlock,
                        phoneTextBlock,
                        ratingTextBlock,
                    }
                }
            };
        }

        public StackPanel GetCards()
        {
            StackPanel mainStackPanel = new StackPanel();

            foreach (var p in _partner)
            {
                Border card = GetCard(p);
                card.MouseDown += (s, e) =>
                {
                    OnCardClicked(p);
                };
                mainStackPanel.Children.Add(card);
            }

            return mainStackPanel;
        }

        private void OnCardClicked(Partner partner)
        {
            new AddEditApplicationWindow(partner).ShowDialog();
        }
    }
}
