using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form2 : Form
    {
        private bool orderInfoPanelLocationSet = false;
        private Button toggleButton;

        private Label selectedPriceLabel;
        private Panel menuBar;
        private Panel contentPanel;
        private Panel orderInfoPanel;
        private TextBox selectedMenuTextBox;
        private TextBox selectedPriceTextBox;
        private TextBox selectedQuantityTextBox;
        private const int OriginalMenuBarHeight = 50; // 처음에 설정된 메뉴 바의 높이

        private bool isOrderInfoPanelExpanded = true;
        private bool firstClick = true;
        private List<SelectedMenuItem> selectedMenuItems = new List<SelectedMenuItem>();
        private Button plusButton;
        private Button minusButton;


        public Form2()
        {
            InitializeDynamicComponents();
            InitializeUI();
        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 700); //나중에 합칠때 화면 크기 변경 필요
            this.ResumeLayout(false);
        }

        private void InitializeContentPanel()
        {
            contentPanel = new Panel();
            contentPanel.BackColor = Color.White;
            contentPanel.Size = new Size(this.Width, 550);
            contentPanel.Location = new Point(0, menuBar.Bottom);

            this.Controls.Add(contentPanel);
        }
 
        private void InitializeOrderInfoPanel()
        {
            if (orderInfoPanel == null)
            {
                orderInfoPanel = new Panel();
                orderInfoPanel.BackColor = Color.FromArgb(75, 137, 220);
                orderInfoPanel.Size = new Size(this.Width, 200); // 기본 높이
                orderInfoPanel.Location = new Point(0, contentPanel.Bottom + 20);
                orderInfoPanelLocationSet = true; //위치 고정 -- toggle누르기 전에 메뉴 버튼 클릭시에는 고정이 안돼서 수정 필요

                selectedMenuTextBox = CreateReadOnlyTextBox();
                selectedMenuTextBox.Font = new Font("Arial", 12, FontStyle.Bold);
                selectedMenuTextBox.ForeColor = Color.White;
                selectedMenuTextBox.Dock = DockStyle.Left;
                selectedMenuTextBox.Width = 200; 

                selectedPriceLabel = new Label();
                selectedPriceLabel.Font = new Font("Arial", 10);
                selectedPriceLabel.ForeColor = Color.White;
                selectedPriceLabel.TextAlign = ContentAlignment.MiddleRight;
                selectedPriceLabel.Dock = DockStyle.Right;
                selectedPriceLabel.Width = 100;

                selectedQuantityTextBox = CreateReadOnlyTextBox();
                selectedQuantityTextBox.Font = new Font("Arial", 10); 
                selectedQuantityTextBox.ForeColor = Color.White;
                selectedQuantityTextBox.Dock = DockStyle.Right;
                selectedQuantityTextBox.Width = 30; 

                AddQuantityButtons();

                int spacing = 10; 
                int margin = 10;   

                selectedMenuTextBox.Margin = new Padding(margin, 10, spacing, 0);
                selectedPriceLabel.Margin = new Padding(0, 10, spacing, 0);
                selectedQuantityTextBox.Margin = new Padding(0, 10, margin, 0);

                orderInfoPanel.Controls.Add(selectedMenuTextBox);
                orderInfoPanel.Controls.Add(selectedPriceLabel);
                orderInfoPanel.Controls.Add(plusButton);
                orderInfoPanel.Controls.Add(minusButton);
                orderInfoPanel.Controls.Add(selectedQuantityTextBox);

                this.Controls.Add(orderInfoPanel);
                toggleButton = new Button();
                toggleButton.Text = "▲";
                toggleButton.Font = new Font("Arial", 12, FontStyle.Bold);
                toggleButton.ForeColor = Color.White;
                toggleButton.BackColor = Color.Transparent;
                toggleButton.FlatStyle = FlatStyle.Flat;

                toggleButton.FlatAppearance.BorderSize = 1;  
                toggleButton.FlatAppearance.BorderColor = Color.White;  

                toggleButton.Width = 20;
                toggleButton.Height = 20;
                toggleButton.TextAlign = ContentAlignment.MiddleCenter; 
                toggleButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                toggleButton.Click += ToggleButton_Click;

                orderInfoPanel.Controls.Add(toggleButton);


                UpdateInfoPanelVisibility();
                isOrderInfoPanelExpanded = true;
                UpdateInfoPanelVisibility();

            }
        }
        private void ToggleButton_Click(object sender, EventArgs e)
        {
            isOrderInfoPanelExpanded = !isOrderInfoPanelExpanded;

            if (isOrderInfoPanelExpanded)
            {
                int newHeight = CalculateOrderInfoPanelHeight();
                orderInfoPanel.Height = newHeight;
                toggleButton.Text = "▲";
            }
            else
            {
                orderInfoPanel.Height = toggleButton.Height;
                toggleButton.Text = "▼";
            }

            orderInfoPanel.Location = new Point(0, contentPanel.Bottom - orderInfoPanel.Height);

            toggleButton.Location = new Point(600, 0);
            toggleButton.BringToFront();

            int newMargin = isOrderInfoPanelExpanded ? 20 : 10;
            orderInfoPanel.Margin = new Padding(0, 0, 0, newMargin);
        }

        private void UpdateInfoPanelVisibility()
        {
            int originalContentPanelBottom = contentPanel.Bottom;

            if (isOrderInfoPanelExpanded)
            {
                orderInfoPanel.Height = CalculateOrderInfoPanelHeight();
                toggleButton.Text = "▼";

                orderInfoPanel.Location = new Point(0, originalContentPanelBottom - orderInfoPanel.Height);
                AddPaymentButtons();
            }
            else
            {
                orderInfoPanel.Height = toggleButton.Height;
                toggleButton.Text = "▲";

                orderInfoPanel.Location = new Point(0, originalContentPanelBottom - toggleButton.Height);
            }

            toggleButton.Location = new Point(600, 0);
            toggleButton.BringToFront();

            int newMargin = isOrderInfoPanelExpanded ? 20 : 10;
            orderInfoPanel.Margin = new Padding(0, 0, 0, newMargin);
        }

        private void AddPaymentButtons()
        {

            Button cardButton = new Button();
            ConfigurePaymentButton(cardButton, "카드");
            cardButton.Click += (sender, e) => CardButton_Click(sender, e);

            Button cashButton = new Button();
            ConfigurePaymentButton(cashButton, "현금");
            cashButton.Click += (sender, e) => CashButton_Click(sender, e);

            Button etcButton = new Button();
            ConfigurePaymentButton(etcButton, "기타");
            etcButton.Click += (sender, e) => EtcButton_Click(sender, e);

            // 적절한 위치에 배치
            cardButton.Location = new Point(10, orderInfoPanel.Bottom + 10);
            cashButton.Location = new Point(cardButton.Right + 10, orderInfoPanel.Bottom + 10);
            etcButton.Location = new Point(cashButton.Right + 10, orderInfoPanel.Bottom + 10);

            // 폼에 추가
            this.Controls.Add(cardButton);
            this.Controls.Add(cashButton);
            this.Controls.Add(etcButton);
        }

        private void ConfigurePaymentButton(Button button, string buttonText)
        {
            button.Text = buttonText;
            button.Font = new Font("Arial", 12, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.BackColor = Color.FromArgb(75, 137, 220);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.White;
            button.Width = 80;
            button.Height = 30;
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            // 카드 결제 버튼 클릭 시 수행할 동작을 작성
            MessageBox.Show("카드 결제를 선택했습니다.");
        }

        private void CashButton_Click(object sender, EventArgs e)
        {
            // 현금 결제 버튼 클릭 시 수행할 동작을 작성합니다.
            MessageBox.Show("현금 결제를 선택했습니다.");
        }

        private void EtcButton_Click(object sender, EventArgs e)
        {
            // 기타 결제 버튼 클릭 시 수행할 동작을 작성합니다.
            MessageBox.Show("기타 결제를 선택했습니다.");
        }



        private int CalculateOrderInfoPanelHeight()
        {
            int offsetY = 4;
            int itemHeight = 30;

            // 기본 높이긴 한데 적용이 안되는 느낌..입니다 다른 코드랑 섞인듯 한 것 같기도 합니다
            int defaultHeight = 100;

            int calculatedHeight = selectedMenuItems.Count * (itemHeight + offsetY) + toggleButton.Height + defaultHeight;

            // 최대 높이 제한
            int maxHeight = contentPanel.Bottom - toggleButton.Height;
            return Math.Min(calculatedHeight, maxHeight);
        }
        private void InitializeUI()
        {
            this.Text = "카페 메뉴 선택";

            menuBar = new Panel();
            menuBar.BackColor = Color.FromArgb(75, 137, 220);
            menuBar.Size = new Size(this.Width, 50);
            menuBar.Location = new Point(0, 0);

            string[] menuCategories = { "카페", "스무디", "에이드", "디저트", "기타" };

            for (int i = 0; i < menuCategories.Length; i++)
            {
                Panel menuPanel = CreateMenuPanel(menuCategories[i]);
                menuPanel.Location = new Point(i * (this.Width / menuCategories.Length), 0);
                menuBar.Controls.Add(menuPanel);
            }

            InitializeContentPanel();
            InitializeOrderInfoPanel();

            this.Controls.Add(menuBar);
            this.Controls.Add(contentPanel);

            UpdateContentPanel("카페");
        }



        private void AddQuantityButtons()
        {
            // 기존의 +/- 버튼 제거
            if (plusButton != null)
                this.Controls.Remove(plusButton);
            if (minusButton != null)
                this.Controls.Remove(minusButton);

            // +/- 버튼
            plusButton = new Button();
            ConfigureButton(plusButton, "+");
            plusButton.Click += PlusButton_Click;

            minusButton = new Button();
            ConfigureButton(minusButton, "-");
            minusButton.Click += MinusButton_Click;


            // 버튼을 form에 추가
            this.Controls.Add(plusButton);
            this.Controls.Add(minusButton);
        }

        private void ConfigureButton(Button button, string buttonText)
        {
            button.Text = buttonText;
            button.Font = new Font("Arial", 8);
            button.ForeColor = Color.White;
            button.BackColor = Color.Transparent;  // 배경색을 투명
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.White;  // 테두리 색을 하얀색
            button.Width = 20;
            button.Height = 20;
        }


        private TextBox CreateReadOnlyTextBox()
        {
            TextBox textBox = new TextBox();
            textBox.ReadOnly = true;
            textBox.BorderStyle = 0;
            textBox.BackColor = orderInfoPanel.BackColor;
            textBox.TabStop = false;
            return textBox;
        }

        private void UpdateOrderInfoPanel()
        {
            if (selectedMenuItems.Count > 0)
            {
                SelectedMenuItem lastSelectedItem = selectedMenuItems[selectedMenuItems.Count - 1];
                selectedMenuTextBox.Text = lastSelectedItem.Menu;
                selectedPriceLabel.Text = $"{lastSelectedItem.Price:C}";
                selectedQuantityTextBox.Text = lastSelectedItem.Quantity.ToString();
            }
        }
        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (selectedMenuItems.Count > 0)
            {
                // 주문 목록에 이미 있는 메뉴인지 확인
                SelectedMenuItem existingItem = selectedMenuItems.Find(item => item.Menu == selectedMenuItems[selectedMenuItems.Count - 1].Menu);

                if (existingItem != null)
                {
                    // 이미 주문한 메뉴일 경우 수량만 증가
                    existingItem.Quantity++;
                    UpdateOrderInfoPanelFromLastItem(existingItem);
                }
                else
                {
                    MessageBox.Show("오류: 주문 목록에 없는 메뉴에 수량을 추가하려고 시도했습니다.");
                }
            }
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (selectedMenuItems.Count > 0)
            {
                // 주문 목록에서 선택한 메뉴 찾기
                SelectedMenuItem existingItem = selectedMenuItems.Find(item => item.Menu == selectedMenuItems[selectedMenuItems.Count - 1].Menu);

                if (existingItem != null)
                {
                    // 이미 주문한 메뉴일 경우 수량 감소
                    if (existingItem.Quantity > 1)
                    {
                        existingItem.Quantity--;
                        UpdateOrderInfoPanelFromLastItem(existingItem);
                    }
                    // 주문 수량이 1인 경우에는 메뉴를 삭제 -- 적용안됨 / 별도의 x버튼 만들던지 이거 수정하던지 해야될 것 같아요
                    else
                    {
                        selectedMenuItems.Remove(existingItem);
                        UpdateOrderInfoPanel();
                    }
                }
                else
                {
                    MessageBox.Show("오류: 주문 목록에 없는 메뉴의 수량을 감소하려고 시도했습니다.");
                }
            }
        }

        private void PlusButton_Click(object sender, EventArgs e, SelectedMenuItem menuItem)
        {
            menuItem.Quantity++;
            UpdateOrderInfoPanelFromLastItem(menuItem);
        }

        private void MinusButton_Click(object sender, EventArgs e, SelectedMenuItem menuItem)
        {
            if (menuItem.Quantity > 1)
            {
                menuItem.Quantity--;
                UpdateOrderInfoPanelFromLastItem(menuItem);
            }
        }


        

        private void UpdateOrderInfoPanelFromLastItem(SelectedMenuItem selectedItem)
        {
            foreach (Control control in orderInfoPanel.Controls)
            {
                if (control is Panel itemPanel)
                {
                    TextBox menuTextBox = itemPanel.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (string)textBox.Tag == selectedItem.Menu);
                    TextBox quantityTextBox = itemPanel.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Name == "quantityTextBox" && textBox.Tag != null && (string)textBox.Tag == selectedItem.Menu);
                    Label priceLabel = itemPanel.Controls.OfType<Label>().FirstOrDefault(label => label.Name == "priceLabel" && label.Tag != null && (string)label.Tag == selectedItem.Menu);

                    if (menuTextBox != null && quantityTextBox != null && priceLabel != null)
                    {
                        menuTextBox.Text = selectedItem.Menu;
                        quantityTextBox.Text = selectedItem.Quantity.ToString();
                        priceLabel.Text = $"{GetMenuPrice(selectedItem.Menu) * selectedItem.Quantity:C}";
                    }
                }
            }

            int offsetY = 4;
            int nameLeftMargin = 10;
            orderInfoPanel.Height = CalculateOrderInfoPanelHeight();

            int orderInfoPanelHeight = selectedMenuItems.Count * (60);
            int itemIndex = selectedMenuItems.IndexOf(selectedItem);
            orderInfoPanel.Height = orderInfoPanelHeight;

            for (int i = 0; i <= itemIndex; i++)
            {

                SelectedMenuItem menuItem = selectedMenuItems[i];

                TextBox menuTextBox = CreateReadOnlyTextBox();
                menuTextBox.Text = menuItem.Menu;
                menuTextBox.Tag = menuItem.Menu;  // 메뉴 이름을 태그로 저장
                menuTextBox.Font = new Font("Arial", 12, FontStyle.Bold);
                menuTextBox.ForeColor = Color.White;
                menuTextBox.Width = 111;

                menuTextBox.Left = 350;

                int yOffset = i == 0 ? -10 : 1;
                menuTextBox.Top = i;
                TextBox quantityTextBox = CreateReadOnlyTextBox();
                quantityTextBox.Text = menuItem.Quantity.ToString();
                quantityTextBox.Font = new Font("Arial", 10);
                quantityTextBox.ForeColor = Color.White;
                quantityTextBox.Left = 605;
                quantityTextBox.Width = 30;
                quantityTextBox.Name = "quantityTextBox"; 
                quantityTextBox.Tag = menuItem.Menu;  

                Button plusButton = new Button();
                ConfigureButton(plusButton, "+");
                plusButton.Click += (s, e) => PlusButton_Click(s, e, menuItem);
                plusButton.Left = quantityTextBox.Right + 5;
                plusButton.Top = quantityTextBox.Top;

                Button minusButton = new Button();
                ConfigureButton(minusButton, "-");
                minusButton.Click += (s, e) => MinusButton_Click(s, e, menuItem);
                minusButton.Left = quantityTextBox.Left - 43;
                minusButton.Top = quantityTextBox.Top;

                Label priceLabel = new Label();
                priceLabel.Text = $"{GetMenuPrice(menuItem.Menu) * menuItem.Quantity:C}";
                priceLabel.Font = new Font("Arial", 10);
                priceLabel.ForeColor = Color.White;
                priceLabel.TextAlign = ContentAlignment.MiddleRight;
                priceLabel.Left = 760;
                priceLabel.Width = 100;
                priceLabel.Name = "priceLabel"; 
                priceLabel.Tag = menuItem.Menu;  

                Panel itemPanel = new Panel();
                itemPanel.BackColor = Color.FromArgb(75, 137, 220);
                itemPanel.Size = new Size(orderInfoPanel.Width, 30);
                itemPanel.Left = 0;
                itemPanel.Top = i * (itemPanel.Height + offsetY) + 30;

                itemPanel.Controls.Add(menuTextBox);
                itemPanel.Controls.Add(priceLabel);
                itemPanel.Controls.Add(plusButton);
                itemPanel.Controls.Add(minusButton);
                itemPanel.Controls.Add(quantityTextBox);

                orderInfoPanel.Controls.Add(itemPanel);
            }
            firstClick = false;
        }


        private void OnMenuSelected(string menuName, int price, int quantity)
        {
            SelectedMenuItem selectedMenuItem = new SelectedMenuItem(menuName, price, quantity);
            selectedMenuItems.Add(selectedMenuItem);
            UpdateOrderInfoPanel();
        }

        private Panel CreateMenuPanel(string menuCategory)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(75, 137, 220);
            panel.Size = new Size(this.Width / 5, 50);
            panel.Location = new Point(0, 0);

            Label label = new Label();
            label.Text = menuCategory;
            label.Font = new Font("Arial", 14, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
            label.Cursor = Cursors.Hand;

            panel.Controls.Add(label);
            label.Click += (sender, e) => MenuPanel_Click(label, e);

            return panel;
        }

        private void MenuPanel_Click(object sender, EventArgs e)
        {
            if (sender is Label selectedLabel)
            {
                foreach (Control control in menuBar.Controls)
                {
                    if (control is Panel menuPanel)
                    {
                        menuPanel.BackColor = Color.FromArgb(75, 137, 220);
                        if (menuPanel.Controls.Count > 0 && menuPanel.Controls[0] is Label label)
                        {
                            label.ForeColor = Color.White;
                        }
                    }
                }

                if (selectedLabel.Parent is Panel selectedPanel)
                {
                    selectedPanel.BackColor = Color.White;
                    foreach (Control control in selectedPanel.Controls)
                    {
                        if (control is Label label)
                        {
                            label.ForeColor = Color.Black;
                            UpdateContentPanel(label.Text);
                            break;
                        }
                    }
                }
            }
        }


        private void DisplayMenuContent(string[] menuNames)
        {
            contentPanel.Controls.Clear();

            int buttonsPerRow = 4;
            int buttonWidth = (contentPanel.Width - 40 - 20 * (buttonsPerRow - 1)) / buttonsPerRow;
            int buttonHeight = 200;
            int baseTop = 30;
            int horizontalGap = 20;
            int baseLeft = (contentPanel.Width - buttonWidth * buttonsPerRow - horizontalGap * (buttonsPerRow - 1)) / 2;
            int verticalGap = 30;

            for (int i = 0; i < menuNames.Length; i++)
            {
                Panel menuPanel = new Panel();
                menuPanel.Size = new Size(buttonWidth, buttonHeight + 50);

                if (i % buttonsPerRow == 0)
                {
                    menuPanel.Location = new Point(baseLeft, baseTop + (i / buttonsPerRow) * (buttonHeight + 20 + verticalGap));
                }
                else
                {
                    menuPanel.Location = new Point(baseLeft + (i % buttonsPerRow) * (buttonWidth + horizontalGap), baseTop + (i / buttonsPerRow) * (buttonHeight + 20 + verticalGap));
                }

                Button menuButton = new Button();
                menuButton.Size = new Size(buttonWidth, buttonHeight);
                menuButton.BackgroundImageLayout = ImageLayout.Zoom;
                menuButton.BackgroundImage = Image.FromFile($@"C:\Users\USER\source\repos\Cafe\{menuNames[i]}.jpg");
                menuButton.ImageAlign = ContentAlignment.TopCenter;
                menuButton.TextAlign = ContentAlignment.BottomCenter;
                menuButton.TextImageRelation = TextImageRelation.ImageAboveText;
                menuButton.Tag = menuNames[i];

                Label menuLabel = new Label();
                menuLabel.Text = menuNames[i];
                menuLabel.Font = new Font("Arial", 10);
                menuLabel.ForeColor = Color.Black;
                menuLabel.TextAlign = ContentAlignment.MiddleCenter;

                Label priceLabel = new Label();
                priceLabel.Text = $"{GetMenuPrice(menuNames[i])}원";
                priceLabel.Font = new Font("Arial", 8);
                priceLabel.ForeColor = Color.Gray;
                priceLabel.TextAlign = ContentAlignment.MiddleCenter;

                menuLabel.Dock = DockStyle.Bottom;
                priceLabel.Dock = DockStyle.Bottom;

                menuPanel.Controls.Add(menuButton);
                menuPanel.Controls.Add(menuLabel);
                menuPanel.Controls.Add(priceLabel);

                menuButton.Click += (s, e) => MenuButton_Click(s, e, (string)menuButton.Tag);

                contentPanel.Controls.Add(menuPanel);
            }
        }

        private int GetMenuPrice(string menuName)
        {
            switch (menuName)
            {
                case "아메리카노":
                case "디카페인 아메리카노":
                    return 3000;
                case "콜드브루":
                    return 3500;
                case "에스프레소":
                    return 2500;
                case "돌체 콜드브루":
                    return 4000;
                case "오트 콜드브루":
                    return 4500;
                case "카라멜 마끼아또":
                    return 4500;
                case "카페 라떼":
                    return 4000;
                case "딸기 스무디":
                    return 4000;
                case "블루베리 스무디":
                    return 4500;
                case "망고 스무디":
                    return 4500;
                case "바나나 스무디":
                    return 4500;
                case "딸기 요거트 스무디":
                    return 4500;
                case "망고 요거트 스무디":
                    return 4500;
                case "타로 블루베리 스무디":
                    return 4500;
                case "자몽 스무디":
                    return 4500;
                case "레몬 에이드":
                    return 4500;
                case "자몽 에이드":
                    return 4500;
                case "오렌지 에이드":
                    return 4500;
                case "청포도 에이드":
                    return 4500;
                case "라임 에이드":
                    return 4500;
                case "딸기 에이드":
                    return 4500;
                case "레드 레몬 에이드":
                    return 4500;
                case "수박 에이드":
                    return 4500;
                case "초코 케이크":
                    return 5000;
                case "치즈 케이크":
                    return 5000;
                case "카스테라":
                    return 500;
                case "녹차 케이크":
                    return 3000;
                case "블루베리 치즈 케이크":
                    return 4500;
                case "티라미수":
                    return 5000;
                case "레드벨벳 치즈 케이크":
                    return 3000;
                case "화이트 케이크":
                    return 5000;
                default:
                    return 0;
            }
        }


        private void OnMenuSelectedInForm2(string menuName, int price, int quantity)
        {
            SelectedMenuItem existingItem = selectedMenuItems.Find(item => item.Menu == menuName);

            if (existingItem != null)
            {
                // 이미 주문한 메뉴일 경우 수량만 증가
                existingItem.Quantity++;
                UpdateOrderInfoPanelFromLastItem(existingItem);
            }
            else
            {
                // 새로운 메뉴를 주문 목록에 추가
                SelectedMenuItem selectedMenuItem = new SelectedMenuItem(menuName, price, quantity);
                selectedMenuItems.Add(selectedMenuItem);

                // +/- 버튼이 추가되어 있지 않으면 추가
                if (plusButton == null || minusButton == null)
                {
                    AddQuantityButtons();
                }

                UpdateOrderInfoPanelFromLastItem(selectedMenuItem);
            }

            UpdateOrderInfoPanelHeight();

            // 주문 정보 패널을 펼친 상태로 업뎃
            isOrderInfoPanelExpanded = true;
            UpdateInfoPanelVisibility();
        }

        private void MenuButton_Click(object sender, EventArgs e, string menuName)
        {
            isOrderInfoPanelExpanded = true;
            UpdateInfoPanelVisibility();

            if (sender is Button menuButton)
            {

                int price = GetMenuPrice(menuName);

                // 선택한 메뉴가 이미 주문 목록에 있는지 확인
                int quantity = 1;

                SelectedMenuItem existingItem = selectedMenuItems.Find(item => item.Menu == menuName);

                if (existingItem != null)
                {
                    // 이미 주문한 메뉴일 경우 수량만 증가
                    existingItem.Quantity++;
                    UpdateOrderInfoPanelFromLastItem(existingItem);
                }
                else
                {
                    // 새로운 메뉴를 주문 목록에 추가
                    SelectedMenuItem selectedMenuItem = new SelectedMenuItem(menuName, price, quantity);
                    selectedMenuItems.Add(selectedMenuItem);

                    // +/- 버튼이 추가되어 있지 않으면 추가합니다.
                    if (plusButton == null || minusButton == null)
                    {
                        AddQuantityButtons();
                    }

                    // 주문 정보 패널을 업데이트합니다.
                    UpdateOrderInfoPanelFromLastItem(selectedMenuItem);


                }
            }
        }
        private void UpdateOrderInfoPanelHeight()
        {
            int orderInfoPanelHeight = CalculateOrderInfoPanelHeight();
            orderInfoPanel.Height = orderInfoPanelHeight;
        }

        private void UpdateContentPanel(string menuCategory)
        {
            string[] menuNames = GetMenuNamesByCategory(menuCategory);
            DisplayMenuContent(menuNames);

            if (selectedMenuItems.Count > 0)
            {
                SelectedMenuItem lastSelectedItem = selectedMenuItems[selectedMenuItems.Count - 1];
                UpdateOrderInfoPanelFromLastItem(lastSelectedItem);
            }
        }


        private string[] GetMenuNamesByCategory(string category)
        {
            switch (category)
            {
                case "카페":
                    return new string[] { "아메리카노", "디카페인 아메리카노", "콜드브루", "에스프레소", "돌체 콜드브루", "오트 콜드브루", "카라멜 마끼아또", "카페 라떼" };
                case "스무디":
                    return new string[] { "딸기 스무디", "블루베리 스무디", "망고 스무디", "바나나 스무디", "딸기 요거트 스무디", "망고 요거트 스무디", "타로 블루베리 스무디", "자몽 스무디" };
                case "에이드":
                    return new string[] { "레몬 에이드", "자몽 에이드", "오렌지 에이드", "청포도 에이드", "라임 에이드", "딸기 에이드", "레드 레몬 에이드", "수박 에이드" };
                case "디저트":
                    return new string[] { "초코 케이크", "치즈 케이크", "카스테라", "녹차 케이크", "블루베리 치즈 케이크", "티라미수", "레드벨벳 치즈 케이크", "화이트 케이크" };
                case "기타":
                    return new string[] { "기타1", "기타2", "기타3", "기타4" }; // 추후 메뉴 수정 필요합니다 (카페 메뉴를 잘 모름,,)
                default:
                    return new string[] { };
            }
        }
        private class SelectedMenuItem
        {
            public string Menu { get; }
            public decimal Price { get; }
            public int Quantity { get; set; }
            public SelectedMenuItem(string menu, decimal price, int quantity)
            {
                Menu = menu;
                Price = price;
                Quantity = quantity;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}