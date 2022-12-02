using RESTWithDonetCore_Calculator.Model;
using System.Collections.Generic;

namespace RESTWithDonetCore_Calculator.Services.Implemetations {
    public interface IPersonService {

        Person Create (Person person);
        Person FindById (long id);
        List<Person> FindAll ();
        Person Update (Person person);
        void Delete (long id);

    }
}
