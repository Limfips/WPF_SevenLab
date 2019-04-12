using System;

namespace FirstProjectWpfApplication
{
    public class Test
    {

        public string MainTest()
        {
            string result;
            Person person;
            DreamProperties pattern;
            person = new Person("Петров");
            person.Properties = DreamProperties.Умный | DreamProperties.Добрый;
            string str = person.Properties.ToString();
            result = "Свойства персоны: " + str;
            pattern = DreamProperties.Богатый | DreamProperties.Умный;
            str = pattern.ToString();
            result += "\nСвойства образца: " + str;

            DreamProperties temp = person.Properties & pattern;
            bool query1, query2, query3, query4, query5;

            //Все свойства образца
            query1 = temp == pattern;

            //Ни одно из свойств
            query2 = (~person.Properties & pattern) == pattern;

            //Некоторые свойства
            query3 = temp > 0;

            //некоторые но не все свойства образца
            query4 = temp > 0 && temp < pattern;

            //только свойства образца
            query5 = temp == pattern && (person.Properties & ~pattern) == 0;

            result += "\nРезультат запросов: \n"
                      + query1 + "\n"
                      + query2 + "\n"
                      + query3 + "\n"
                      + query4 + "\n"
                      + query5 + "\n";

            return result;
        }

        public string SecontTest()
        {
            
            string result = "";
            Person[] persons = new Person[5];
            persons[0] = new Person("Петров");
            persons[0].Properties = DreamProperties.Умный | DreamProperties.Добрый;
            persons[1] = new Person("Фролов");
            persons[1].Properties = DreamProperties.Умный | DreamProperties.Богатый;
            persons[2] = new Person("Климов");
            persons[2].Properties = DreamProperties.Богатый | DreamProperties.Добрый;
            persons[3] = new Person("Карпов");
            persons[3].Properties = DreamProperties.Умный;
            persons[4] = new Person("Иванов");
            persons[4].Properties = DreamProperties.Добрый;

            Person newPerson = FindOnePerson(persons,DreamProperties.Богатый | DreamProperties.Умный);

            if (newPerson!=null)
            {
                result = newPerson.Fam;
            }
            
            return result;
        }

        private Person FindOnePerson(Person[] persons, DreamProperties pattern)
        {
            foreach (Person person in persons)
                if ((person.Properties & pattern) == pattern)
                    return person;
            return null;
        }
    }
    [Flags]
    public enum DreamProperties
    {
        Умный = 1,
        Добрый = 2,
        Богатый = 4
    }
    public class Person
    {
        public DreamProperties Properties;
        private string _fam = "";

        public string Fam
        {
            set
            {
                if (_fam == "") _fam = value;
            }
            get { return (_fam); }
        }

        public Person()
        {
        }

        public Person(string fam)
        {
            this._fam = fam;
        }
    }

    class TestTime
    {
        public  object GetTime()
        {
            return 0L;
        }
        public delegate double DtoD(double arg1);
        public double EvalTimeDtoD(int count, DtoD fun, double
            x)
        {
            DateTime start, finish;
            double res;
            start = DateTime.Now;
            for (int i = 1; i < count; i++)
                fun(x);
            finish = DateTime.Now;
            res = (finish - start).Milliseconds;
            return res;
        }
    }
}

/*using System;
using System.Windows;

namespace FirstProjectWpfApplication
{
    public partial class TestMetoddichka : Window
    
{
        private readonly Test _test = new Test();
        private readonly TestTime _testTime = new TestTime();
        public TestMetoddichka()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(XValue.Text);
            TextBlockFirstResult.Text = _test.ZeroTest(x).ToString();
            TextBlockSecondResult.Text = _test.SecontTest();
            TimeMethod.Text = _testTime.EvalTimeDtoD(100000000,_test.ZeroTest,x).ToString();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow w1 = new MainWindow();
            w1.Show();
        }
}
}

/*<Image Source="myImage.jpg"
                   x:Name="Image"
                   Canvas.Top="100"
                   Height="100"
                   MouseLeftButtonUp="Recast"
                   Visibility="Hidden"
            />
            
            <TextBlock Text="Ваш счет"
                       Canvas.Top="20"
                       Canvas.Left="10"/>
            
            <TextBlock x:Name="TextBlock"
                       Height="20"
                       Width="100"
                       Padding="2"
                       Text="0"
                       Background="Navy"
                       Canvas.Top="20"
                       Canvas.Left="70"
                       Foreground="White"/>
            
            <Button x:Name="Button"
                    Height="30"
                    Width="100"
                    Content="Начать игру!"
                    Canvas.Top="50"
                    Canvas.Left="20"
                    Click="StartGame"
                    Visibility="Visible"/>
                    <Button x:Name="Button1"
                    Background="Green" 
                    Content="Top 20 Left 40" 
                    Canvas.Top="170" 
                    Canvas.Left="40"
                    Height="30"
                    Width="100"
                    Foreground="White"
                    Click="BaseFirst"/>
            <Button Background="White"
                    Content="Exit"
                    Canvas.Top="220"
                    Height="20"
                    Canvas.Left="40"
                    Click="ExitProg"/>
            
            <RepeatButton Background="White"
                    Content="Repeat"
                    Canvas.Top="260"
                    Canvas.Left="40"
                    Click="RepeatProg"/>
                    
                    
                    // XAML код
                    
                        public partial class MainWindow
    {
        private int i = 1;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            
            
            
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            if (i == 10)
            {
                timer.Stop();
                Button.Visibility = Visibility.Visible;
                Image.Visibility = Visibility.Hidden; 
            }
            i++;
        }

        private void BaseFirst(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажата зеленая кнопка");
        }
        private void ExitProg(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void RepeatProg(object sender, RoutedEventArgs e)
        {
            int x =  Convert.ToInt32(TextBlock.Text);
            x += 1;
            TextBlock.Text = x.ToString();
        }

        void StartGame(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = 0.ToString();
            Button.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;

            i = 0;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }

        private void Recast(object sender, RoutedEventArgs e)
        {
             Random random = new Random();
            RepeatProg(sender,e);
                    double r = random.Next(20,901);
                    double t = random.Next(20,401);
                    Canvas.SetRight(Image,r);
                    Canvas.SetTop(Image,t);
                
            
        }
                    */