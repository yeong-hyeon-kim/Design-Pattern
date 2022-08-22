namespace Creational_Builder
{
    /* 생성(Creational) - 빌더(Builder) */
    // 생성자의 가독성을 높이는 패턴입니다.

    public class LanguageGrade
    {
        public string CSharpe;
        public string Python;
        public string JavaScript;
        public string TypeScript;

        public LanguageGrade(string CSharpe, string Python, string JavaScript, string TypeScript)
        {
            this.CSharpe = CSharpe;
            this.Python = Python;
            this.JavaScript = JavaScript;
            this.TypeScript = TypeScript;
        }
    }

    // 매개변수가 많은 생성자는 나중에 수정이나 변경이 어렵기 때문에 빌더를 이용합니다.
    public class LanguageBuilder
    {
        private LanguageGrade languageGrade;
        public LanguageBuilder()
        {
            languageGrade = new LanguageGrade("A", "B", "C", "D");
        }

        public LanguageBuilder SetCSharpe(string value)
        {
            languageGrade.CSharpe = value;
            return this;
        }

        public LanguageBuilder SetPython(string value)
        {
            languageGrade.Python = value;
            return this;
        }

        public LanguageBuilder SetJavaScript(string value)
        {
            languageGrade.JavaScript = value;
            return this;
        }

        public LanguageBuilder SetTypeScript(string value)
        {
            languageGrade.TypeScript = value;
            return this;
        }

        public LanguageGrade ToBuild()
        {
            return languageGrade;
        }
    }

    class Program
    {
        static void Main()
        {
            LanguageBuilder languageBuilder = new LanguageBuilder();

            languageBuilder.SetCSharpe("A");
            languageBuilder.SetPython("A");
            languageBuilder.SetJavaScript("A");
            languageBuilder.SetTypeScript("A");

            Console.WriteLine(languageBuilder.ToBuild().TypeScript);
        }
    }
}