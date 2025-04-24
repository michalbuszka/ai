using OxyPlot;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RuchyBrowna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Wykres wykres;
        public MarcovMotion motion = new();

        public MainWindow()
        {
            InitializeComponent();
            wykres = new Wykres();

            motion.GenerateMarcov();
            motion.GenerateBrown();

            wykres.DrawChart(wykres.marcovModel, "Proces Marcova", motion.MarcovData);
            wykres.DrawChart(wykres.brownModel, "Proces Browna", motion.BrownData);
            motion.Generate2DMarcov(); 
            wykres.DrawChart2D(wykres.marcov2DModel, "Proces Marcova 2D", motion.dwoDMarcovDataX, motion.dwoDMarcovDataY); // dodaj to
            DataContext = wykres;
        }
    }
}