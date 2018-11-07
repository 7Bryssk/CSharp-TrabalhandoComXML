using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tela1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = CarregarTitulo();
            CriarContato();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXML = new XmlDocument();

            documentoXML.Load(@"C:\Users\Patty\Google Drive\Treinamento C#\XML\Tela1\Agenda.xml");

            XmlNode noTitulo = documentoXML.SelectSingleNode("/agenda/titulo");

            return noTitulo.InnerText;
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXML = new XmlDocument();

            documentoXML.Load(@"C:\Users\Patty\Google Drive\Treinamento C#\XML\Tela1\Agenda.xml");

            XmlNodeList contatos = documentoXML.SelectNodes("/agenda/contatos/contato");

            foreach (XmlNode node in contatos)
            {
                string representacao = "";
                string id = node.Attributes["id"].Value;
                string nome = node.Attributes["nome"].Value;
                string idade = node.Attributes["idade"].Value;
                representacao = id + " " + nome + " " + idade;
                lbxContatos.Items.Add(representacao);
            }

        }
        private void CriarContato()
        {
            XmlDocument documentoXML = new XmlDocument();
            documentoXML.Load(@"C:\Users\Patty\Google Drive\Treinamento C#\XML\Tela1\Agenda.xml");
            XmlAttribute atributeId = documentoXML.CreateAttribute("id");
            XmlAttribute atributeNome = documentoXML.CreateAttribute("nome");
            XmlAttribute atributeIdade = documentoXML.CreateAttribute("idade");

            atributeId.Value = "5";
            atributeNome.Value = "Jão";
            atributeIdade.Value = "35";

            XmlNode novoContato = documentoXML.CreateElement("contato");

            novoContato.Attributes.Append(atributeId);
            novoContato.Attributes.Append(atributeNome);
            novoContato.Attributes.Append(atributeIdade);

            XmlNode contatos = documentoXML.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);

            documentoXML.Save(@"C:\Users\Patty\Google Drive\Treinamento C#\XML\Tela1\Agenda.xml");
        }
    }
}
