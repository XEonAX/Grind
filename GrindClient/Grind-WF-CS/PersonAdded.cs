using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Grind_WF_CS
{
    public partial class PersonAdded : Form
    {
        public PersonAdded()
        {
            InitializeComponent();
        }



        RestClient rRestClient = new RestClient();
        IRestResponse rRestResponse;
        RestRequest rRestRequest = new RestRequest();
        JsonDeserializer JSONDeserilizer = new JsonDeserializer();
        JsonSerializer JSONSerilizer = new JsonSerializer();

        private void PersonAdded_Load(object sender, EventArgs e)
        {

            rRestClient = new RestClient("http://localhost:4567/");
            dupLevel.SelectedIndex = 3;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.name = txtName.Text;
            person.trigram = txtTrigram.Text;
            person.internal_object_id = txtIntObjId.Text;
            person.active = cbActive.Checked;
            person.level = (eLevel)dupLevel.SelectedIndex;

            person = AddPerson(person);
        }

        private Person AddPerson(Person _person)
        {
            RootPerson RP = new RootPerson();
            RP.person = _person;
            rRestRequest = new RestRequest();
            rRestRequest.Resource = "person";
            rRestRequest.Method = Method.POST;
            rRestRequest.RequestFormat = DataFormat.Json;
            rRestRequest.AddBody(RP);
            
            rRestResponse = rRestClient.Execute(rRestRequest);
            return JSONDeserilizer.Deserialize<Person>(rRestResponse);
        }
    }
}
