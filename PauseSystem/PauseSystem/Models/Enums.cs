using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PauseSystem.Models
{
    public static class ExpressionExtensions
    {

        public enum Vis
        {
            Alle = 0,
            Aktive = 1,
            IkkeAktive = 2,
            Pause = 4,
            PauseOgAktiv = 8
        }
        //public static string UppercaseFirst(this string s)
        //{
        //    if (string.IsNullOrEmpty(s))
        //    {
        //        return string.Empty;
        //    }
        //    char[] a = s.ToCharArray();
        //    a[0] = char.ToUpper(a[0]);
        //    return new string(a);
        //}

        public static string PropertyName<TProperty>(this Expression<Func<TProperty>> projection)
        {
            var memberExpression = projection.Body as MemberExpression;

            if (memberExpression == null)
                return null;

            return memberExpression.Member.Name;
        }

    }
    public enum Ændring
    {
        Ændret = 0, Slettet = 1, Tilføjet = 2
    }

    public enum KundeType
    {
        PartnerService = 2,
        MonsterService = 1
    }

    public enum BrugerRolle
    {
        Ingen = 0,
        Admin,
        Bruger,
        Lager

    }

    public enum Interval
    {
        HverUge = 0,
        Lige = 1,
        Ulige = 2,
        FørstDagHverMåned = 3,
        SidstDagHverMåned = 4,
        Hver2uge = 5,
        Hver3uge = 6,
        Hver4uge = 7,
        Hver5uge = 8,
        Hver6uge = 9,
        Hver7uge = 10,
        Hver8uge = 11,
        Hver9uge = 12,
        Hver10uge = 13,
        Hver11uge = 14,
        Hver12uge = 15,
        Hver26uge = 16,
        FørstArbejdsdagIMåned = 17,
        SidstArbejdsdagIMåned = 18,
        FørsteValgteDagIMåned = 19,
        SidsteValgteDagIMåned = 20,
        LigeMåned = 21,
        UligeMåned = 22,
        MåtteSkift = 23
    }

    public enum Volume
    {
        Kurve = 0,
        Kasser,
        Halvkasser

    }


    public static class Global
    {
        public static string Extern = "Extern";
        public static string Ydelser = "Ydelser";
        public static string Tillæg = "Tillæg";

    }
}