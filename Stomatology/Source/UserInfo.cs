using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomatology
{
    public partial class UserInfo : Form
    {
        double number = 0;
        int leftArrow;
        int rightArrow;
        int setVisible;
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            char s = '"';
            toolTip();
            rtxtAboutSoft.Text = "Dentistry це програма для Windows - надійний інструмент для роботи зі стоматологіями." +
                "\n\nDentistry для Windows доступний в одному варіанті \n\nDentistry.exe - версія з графічним інтерфейсом(GUI);" +
                "\n\nDentistry і модулі самі розпаковуються \n\nDentistry працюють в середовищі Windows XP SP3 і новіше.";
            rtxtInterface.Text = "В цьому розділі коротко описані основні частини інтерфейса Dentistry." +
                "\n\n Меню Dentistry має настуані пункти: " + s + "Головна" + s + ",\n" + s + "Справка" + s + ", " + s + "Допомога" + s + "." +
                "\n Пункт " + s + "Головна" + s + " включає в себе два підпункта: " + s + "Налаштування" + s + " - що " +
                "служить для вибору або редагування шляху до бази даних та программи для віддаленої допомоги TeamViewer," +
                " та " + s + "Вихід" + s + "- кнопка для виходу з программи." +
                "\n Пункт " + s + "Справка" + s + " включає в себе два підпункти: " + s + "Посібник користувача" + s + " - що є" +
                "головним пунктом для новачків в користуванні програмою Dentistry та пункт " + s + "Про программу" + s + " - форма в якій вказано " +
                "головні відомості по технічній частині программи такі як назва, версія та інформація про розробника. " +
                "\n Пункт " + s + "Допомога" + s + " включає в себе два підпункти: " + s + "Контакти" + s + " - де вказані " +
                "контакти про розробника та шляхи по яким можна з'вязатися з розробником, та " + s + "Віддалена допомога" + s + " " +
                " - включає в собі можливість з'вязатися з розробником за попереднім звінком та вказаним шляхом до TeamViewer." +
                "\n\nРобоча частина програми є головним полем для взаємодії з користувачем. " +
                "\n\n\tЛіва половина поля" +
                " включає в собі дві кнопки: " + s + "Додати нового паціента" + s + " та " + s + "Редагувати паціента" + s + " " +
                "і таблиця на якій відображаються всі паціенти які коли-небуть були внесені в базу та відвідували ваш заклад. " +
                "Таблиця служить для того щоб переглянути інформацію про паціента та надає можливість переглянути всі прийоми " +
                "даного паціента по датам при виборі." +
                "\n\n\t Права половина поля включає в собі також дві кнопки: " + s + "Додати новий прийом " + s + "та " + s + " Оновити дані" + s + "" +
                "і панель яка дозволяє редагувати паціента.";
            rtxtSettings.Text = "Шлях до БД (База Даних) - для того щоб вказати шлях до бази даних зробіть подвійне натискання на ЛКМ (Ліва Кнопка Мишки), після того як відкриється вікно вибору шляху," +
                "перейдіть до папки у якій у вас знаходить " + s + ".mdf" + s + " файл, виберіть його та нажміть кнопку " + s + "ОК" + s + " для того щоб підтвердити ваш вибір. Шлях до БД обов'язково потрібно " +
                "вказати для того щоб у вас був доступ до башої бази даних та ви могли з нею працювати!" +
                "\n\nШлях до TV (TeamViewer) - для того щоб вказати шлях до TeamViewer зробіть подвійне натискання на ЛКМ (Ліва Кнопка Мишки), після того як відкриється вікно вибору шляху," +
                "перейдіть до папки у якій у вас знаходить " + s + "TeamViewer.exe" + s + " , виберіть його та нажміть кнопку " + s + "ОК" + s + " для того щоб підтвердити ваш вибір. Шлях до TV не обов'язковий для" +
                " вказення, його також можна ввести після запуску програми в пункті " + s + "Головна" + s + " -> " + s + "Налаштування" + s + ". Але ми рекомендуємо вам встановити шлях відпразу,щоб программа" +
                "запускалася віздразу з головного меню а не з Налаштувань, та для того щоб в майбутьньому " +
                "у вас була можливість зв'язатися з нами.";
        }

        public void toolTip()
        {

        }


        private void selectBoxByButton()
        {
            switch (number)
            {
                case 1:
                    {
                        setVisible = 1;
                        setVisibility();
                        break;
                    }
                case 2:
                    {
                        setVisible = 2;
                        setVisibility();
                        break;
                    }
                case 3:
                    {
                        setVisible = 3;
                        setVisibility();
                        break;
                    }
            }
        }
        private void setVisibility()
        {
            switch (setVisible)
            {
                case 1:
                    {
                        gBoxAboutSoft.Visible = true;
                        gBoxInterface.Visible = false;
                        gBoxSettings.Visible = false;
                        break;
                    }
                case 2:
                    {
                        gBoxAboutSoft.Visible = false;
                        gBoxInterface.Visible = true;
                        gBoxSettings.Visible = false;
                        break;
                    }
                case 3:
                    {
                        gBoxAboutSoft.Visible = false;
                        gBoxInterface.Visible = false;
                        gBoxSettings.Visible = true;
                        break;
                    }
            }
        }
        #region Кнопки
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    {
                        leftArrow = 1;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        leftArrow = 2;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        leftArrow = 3;
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            switch(number)
            {
                case 0:
                    {
                        leftArrow = 2;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 1:
                    {
                        leftArrow = 1;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        leftArrow = 3;
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
            }
        }
        private void toolStripSplitButton4_ButtonClick(object sender, EventArgs e)
        {
            switch (number)
            {
                case 0:
                    {
                        leftArrow = 3;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
                case 1:
                    {
                        leftArrow = 1;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        leftArrow = 2;
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }
        #endregion
        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            switch(leftArrow)
            {
                case 1:
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        switch (number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        switch(number)
                        {
                            case 1:
                                {
                                    rightArrow = 1;
                                    break;
                                }
                            case 2:
                                {
                                    rightArrow = 2;
                                    break;
                                }
                            case 3:
                                {
                                    rightArrow = 3;
                                    break;
                                }
                        }
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            switch(rightArrow)
            {
                case 1:
                    {
                        number = 1;
                        selectBoxByButton();
                        break;
                    }
                case 2:
                    {
                        number = 2;
                        selectBoxByButton();
                        break;
                    }
                case 3:
                    {
                        number = 3;
                        selectBoxByButton();
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
    
}