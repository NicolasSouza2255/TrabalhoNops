using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Verificador
{
    public string UltReg;
    public bool Nop;

   

    public bool VerificaOperacoes(string line)
    {
        //Operaçoes especificas como  Lw, Sw, Addi, Slt
        string str = line.Substring(0, 6);

        if (str == "001000")
            return true;

        if (str == "101011")
            return true;

        if (str == "100011")
            return true;

        if (str == "001010")
            return true;

        else
            return false;

    }

    public bool VerificaR(string line)
    {
        if (line.Substring(0, 6) == "000000")
            return true;
        else
            return false;

    }

    public bool VerificaSyscalEOutros(string line)
    {
        if (line == "00000000000000000000000000001100")
            //Syscall
            return true;

        if (line == "00000000000000000000000000000000")
            //Nao Operação
            return true;

        return false;
    }

    public bool ValidarRegistrador(string line)
    {
       
        if (VerificaSyscalEOutros(line))
            return false;

        if (Nop)
        {
            if (VerificaR(line))
            {
                if (line.Substring(6, 5) == UltReg)
                    return true;

                if (line.Substring(11, 5) == UltReg)
                    return true;
            }

            if (VerificaOperacoes(line))
            {
                if (line.Substring(6, 5) == UltReg)
                    return true;
            }
        }
        else if (VerificaR(line) || VerificaOperacoes(line))
        {
            Nop = true;

            if (VerificaR(line))
                UltReg = line.Substring(16, 5);


            else if (VerificaOperacoes(line))
                UltReg = line.Substring(11, 5);
        }
        else
            Nop = false;


        return false;
    }

   
}
