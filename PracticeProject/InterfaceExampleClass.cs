using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    public class InterfaceExampleClass : I1, I2
    {
        public void read()
        {
            throw new NotImplementedException();
        }


        void I1.write()
        {
            throw new NotImplementedException();
        }

        void I2.write()
        {
            throw new NotImplementedException();
        }
    }



    public interface I1
    {
        void write();
    }

    public interface I2
    {
        void write();

        void read();


    }


    public class main
    {
          void MainMethod()
        {
            I1 obj = new InterfaceExampleClass();

            obj.write();





        }
    }


    public abstract class AbClass : main
    {


    }

}
