using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Laycode
{
    public class str
    {


        #region 字符串查找某词出现的次数及索引

        public class keywordfindindexitem
        {
            public keywordfindindexitem()
            {
                indexs = new List<int>();
            }
            public string key { get; set; }
            public List<int> indexs { get; set; }
        }

        public static List<keywordfindindexitem> Getkeywordfindindexitems(string oldstring, params string[] listkeys)
        {
            var keywordfindindexitems = new List<keywordfindindexitem>();

            for (int i = 0; i < listkeys.Length; i++)
            {
                var keywordfindindexitem = thekeyInstring(oldstring, listkeys[i]);
                if (keywordfindindexitem.indexs.Count() <= 1)
                {
                    continue;
                }
                keywordfindindexitems.Add(keywordfindindexitem);
            }


            return keywordfindindexitems;
        }

        public static int GetkeywordfindindexitemsINDEXScount(List<keywordfindindexitem> keywordfindindexitems)
        {
            var count = 0;

            for (int i = 0; i < keywordfindindexitems.Count; i++)
            {
                var a = keywordfindindexitems[i];
                count = count + a.indexs.Count();

            }


            return count;
        }

        public static keywordfindindexitem thekeyInstring(string oldstring, string keyWord)
        {
            var keywordfindindexitem = new keywordfindindexitem();
            keywordfindindexitem.key = keyWord;
            //统计出字符串中，下雪出现的次数，并每次出现的索引位置；
            string text = oldstring;
            int index = 0;
            int count = 0;
            while ((index = text.IndexOf(keyWord, index)) != -1)
            {
                count++;
                //Console.WriteLine("第{0}次；索引是{1}", count, index);
                index = index + keyWord.Length;
                keywordfindindexitem.indexs.Add(index);
            }
            return keywordfindindexitem;
        }

        //随机索引对象
        public static keywordfindindexitem getRandomitemFromIndexsitems(List<keywordfindindexitem> keywordfindindexitems)
        {

            var rid = CsharpLazycode.Module.Laycode.random.Next(0, keywordfindindexitems.Count);
            if (keywordfindindexitems.IsNullOrEmpty() == false && keywordfindindexitems.Count > 0)
            {
                return keywordfindindexitems[rid];
            }

            return new keywordfindindexitem();
        }
        //随机索引
        [Obsolete]
        public static int getRandomIndexFromIndexsitems(List<keywordfindindexitem> keywordfindindexitems)
        {
            var keywordfindindexitem = getRandomitemFromIndexsitems(keywordfindindexitems);

            var rid = CsharpLazycode.Module.Laycode.random.Next(0, keywordfindindexitem.indexs.Count);
            if (keywordfindindexitem.indexs.IsNullOrEmpty() == false && keywordfindindexitem.indexs.Count > 0)
            {
                return keywordfindindexitem.indexs[rid];
            }

            return 0;
        }
        //失败返回-1 成功大于0
        public static int getRandomCanInsertNextIndexValueFromIndexsitems(string oldstring, List<keywordfindindexitem> keywordfindindexitems)
        {
            var keywordfindindexitem = getRandomitemFromIndexsitems(keywordfindindexitems);
            var oknextindex = -1;
            var okindex = 0;
            var count = 0;
            while (true)
            {
                count++; if (count >= 10 || Go001() == true) { break; }
            }

            bool Go001()
            {
                var rid = CsharpLazycode.Module.Laycode.random.Next(0, keywordfindindexitem.indexs.Count - 1);
                if (keywordfindindexitem.indexs.IsNullOrEmpty() == false && keywordfindindexitem.indexs.Count > 0)
                {
                    okindex = keywordfindindexitem.indexs[rid];
                    var tmp = oldstring.IndexOf(keywordfindindexitem.key, okindex);
                    if (tmp > 0)
                    {
                        oknextindex = tmp;
                        return true;
                    }

                }
                return false;
            }

            return oknextindex;
        }




        //常用中文标点获取

        #endregion


        /// <summary>
        /// 取文本中间
        /// </summary>
        /// <param name="allStr">原字符</param>
        /// <param name="firstStr">前面的文本</param>
        /// <param name="lastStr">后面的文本</param>
        /// <returns>返回获取的值</returns>
        public static string GetStringMid(string str, string str1, string str2)
        {
            int leftlocation;//左边位置
            int rightlocation;//右边位置
            int strmidlength; ;//中间字符串长度
            string strmid;//中间字符串
            leftlocation = str.IndexOf(str1);
            //获取左边字符串头所在位置
            if (leftlocation == -1)//判断左边字符串是否存在于总字符串中
            {
                return "";
            }
            leftlocation = leftlocation + str1.Length;//获取左边字符串尾所在位置
            rightlocation = str.IndexOf(str2, leftlocation);
            //获取右边字符串头所在位置
            if (rightlocation == -1 || leftlocation > rightlocation)//判断右边字符串是否存在于总字符串中，左边字符串位置是否在右边字符串前
            {
                return "";
            }
            strmidlength = rightlocation - leftlocation;//计算中间字符串长度
            strmid = str.Substring(leftlocation, strmidlength);//取出中间字符串
            return strmid;//返回中间字符串
        }
        public static string Getzhongfuzifustr(string zfZI, int count)
        {
            var a = "";
            for (int i = 0; i < count; i++)
            {
                a = a + zfZI;
            }
            if (a == "")
            {
                return zfZI;
            }

            return a;
        }

        public static bool ReplaceOnetime(string body, String oldValue, String newValue)
        {

            try
            {
                Regex r = new Regex(oldValue);
                body = r.Replace(body, newValue, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常包: [{0}] [{1}] 异常消息:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return true;
        }

        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        #region public static string FilterChar(string inputValue) 过滤特殊字符，保留中文，字母，数字，和- [经过测试有bug 已放弃用]
        /// <summary>
        /// 过滤特殊字符，保留中文，字母，数字，和-
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <remarks>发件和收件详细地址有这种情况：“仓场路40-73号迎园新村四坊69号202室”，这种带有-的特殊字符不需要过滤掉</remarks>
        /// <returns></returns>
        [Obsolete]
        public static string FilterChar(string inputValue)
        {
            // var a = CsharpLazycode.Module.Laycode.str.FilterChar("asdfas 阿萨德 @#$%@#$^%#$^ -asd 你");
            // return Regex.Replace(inputValue, "[`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）&mdash;|{}【】；‘’，。/*-+]+", "", RegexOptions.IgnoreCase);
            if (Regex.IsMatch(inputValue, "[A-Za-z0-9\u4e00-\u9fa5-]+"))
            {
                return Regex.Match(inputValue, "[A-Za-z0-9\u4e00-\u9fa5-]+").Value;
            }
            return "";
        }
        #endregion

        public static string FilterCharIncludeUnderline(string inputValue)
        {
            return Regex.Replace(inputValue, "[^0-9A-Za-z]", "");
        }


        /// <summary>
        /// 把特殊字符替换为空
        /// 当前特殊字符为:!"#$%&'()*+,-./:;<=>?@[\]^_`{|}~！＂＃＄％＆＇（）＊＋，－．／：；＜＝＞？＠［＼］＾＿｀｛｜｝～
        /// </summary>
        /// <param name="oldstr"></param>
        /// <returns></returns>
        public static string ReplaceSpecialCharactersWithNull(string oldstr)
        {
            var te = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~！＂＃＄％＆＇（）＊＋，－．／：；＜＝＞？＠［＼］＾＿｀｛｜｝～";
            var arr = te.ToArray();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
                oldstr = oldstr.Replace(item.ToString(), "");
            }

            return oldstr;

        }
        /// <summary>
        /// 替换字符串中的特殊字符符号 第二版
        /// 算法为:以原始字符串分割去寻找目标特殊字符串合集里的数据,比对
        /// </summary>
        /// <param name="oldstr"></param>
        /// <returns></returns>
        public static string ReplaceSpecialCharactersWithNull_Version2(string oldstr)
        {
            var te = "❤❥웃유♋☮✌☏☢☠✔☑♚▲♪✈✞÷↑↓◆◇⊙■□△▽¿─│♥❣♂♀☿Ⓐ✍✉☣☤✘☒♛▼♫⌘☪≈←→◈◎☉★☆⊿※¡━┃♡ღツ☼☁❅♒✎©®™Σ✪✯☭➳卐√↖↗●◐Θ◤◥︻〖〗┄┆℃℉°✿ϟ☃☂✄¢€£∞✫★½✡×↙↘○◑⊕◣◢︼【】┅┇☽☾✚〓▂▃▄▅▆▇█▉▊▋▌▍▎▏↔↕☽☾の•▸◂▴▾┈┊①②③④⑤⑥⑦⑧⑨⑩ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩ㍿▓♨♛❖♓☪✙┉┋☹☺☻تヅツッシÜϡﭢ™℠℗©®♥❤❥❣❦❧♡۵웃유ღ♋♂♀☿☼☀☁☂☄☾☽❄☃☈⊙☉℃℉❅✺ϟ☇♤♧♡♢♠♣♥♦☜☞☝✍☚☛☟✌✽✾✿❁❃❋❀⚘☑✓✔√☐☒✗✘ㄨ✕✖✖⋆✢✣✤✥❋✦✧✩✰✪✫✬✭✮✯❂✡★✱✲✳✴✵✶✷✸✹✺✻✼❄❅❆❇❈❉❊†☨✞✝☥☦☓☩☯☧☬☸✡♁✙♆。，、＇：∶；?‘’“”〝〞ˆˇ﹕︰﹔﹖﹑•¨….¸;！´？！～—ˉ｜‖＂〃｀@﹫¡¿﹏﹋﹌︴々﹟#﹩$﹠&﹪%*﹡﹢﹦﹤‐￣¯―﹨ˆ˜﹍﹎+=<＿_-\\ˇ~﹉﹊（）〈〉‹›﹛﹜『』〖〗［］《》〔〕{}「」【】︵︷︿︹︽_﹁﹃︻︶︸﹀︺︾ˉ﹂﹄︼☩☨☦✞✛✜✝✙✠✚†‡◉○◌◍◎●◐◑◒◓◔◕◖◗❂☢⊗⊙◘◙◍⅟½⅓⅕⅙⅛⅔⅖⅚⅜¾⅗⅝⅞⅘≂≃≄≅≆≇≈≉≊≋≌≍≎≏≐≑≒≓≔≕≖≗≘≙≚≛≜≝≞≟≠≡≢≣≤≥≦≧≨≩⊰⊱⋛⋚∫∬∭∮∯∰∱∲∳%℅‰‱㊣㊎㊍㊌㊋㊏㊐㊊㊚㊛㊤㊥㊦㊧㊨㊒㊞㊑㊒㊓㊔㊕㊖㊗㊘㊜㊝㊟㊠㊡㊢㊩㊪㊫㊬㊭㊮㊯㊰㊙㉿囍♔♕♖♗♘♙♚♛♜♝♞♟ℂℍℕℙℚℝℤℬℰℯℱℊℋℎℐℒℓℳℴ℘ℛℭ℮ℌℑℜℨ♪♫♩♬♭♮♯°øⒶ☮✌☪✡☭✯卐✐✎✏✑✒✍✉✁✂✃✄✆✉☎☏➟➡➢➣➤➥➦➧➨➚➘➙➛➜➝➞➸♐➲➳⏎➴➵➶➷➸➹➺➻➼➽←↑→↓↔↕↖↗↘↙↚↛↜↝↞↟↠↡↢↣↤↥↦↧↨➫➬➩➪➭➮➯➱↩↪↫↬↭↮↯↰↱↲↳↴↵↶↷↸↹↺↻↼↽↾↿⇀⇁⇂⇃⇄⇅⇆⇇⇈⇉⇊⇋⇌⇍⇎⇏⇐⇑⇒⇓⇔⇕⇖⇗⇘⇙⇚⇛⇜⇝⇞⇟⇠⇡⇢⇣⇤⇥⇦⇧⇨⇩⇪➀➁➂➃➄➅➆➇➈➉➊➋➌➍➎➏➐➑➒➓㊀㊁㊂㊃㊄㊅㊆㊇㊈㊉ⒶⒷⒸⒹⒺⒻⒼⒽⒾⒿⓀⓁⓂⓃⓄⓅⓆⓇⓈⓉⓊⓋⓌⓍⓎⓏⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩ⒜⒝⒞⒟⒠⒡⒢⒣⒤⒥⒦⒧⒨⒩⒪⒫⒬⒭⒮⒯⒰⒱⒲⒳⒴⒵ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫⅬⅭⅮⅯⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹⅺⅻⅼⅽⅾⅿ┌┍┎┏┐┑┒┓└┕┖┗┘┙┚┛├┝┞┟┠┡┢┣┤┥┦┧┨┩┪┫┬┭┮┯┰┱┲┳┴┵┶┷┸┹┺┻┼┽┾┿╀╁╂╃╄╅╆╇╈╉╊╋╌╍╎╏═║╒╓╔╕╖╗╘╙╚╛╜╝╞╟╠╡╢╣╤╥╦╧╨╩╪╫╬◤◥◄►▶◀◣◢▲▼◥▸◂▴▾△▽▷◁⊿▻◅▵▿▹◃❏❐❑❒▀▁▂▃▄▅▆▇▉▊▋█▌▍▎▏▐░▒▓▔▕■□▢▣▤▥▦▧▨▩▪▫▬▭▮▯㋀㋁㋂㋃㋄㋅㋆㋇㋈㋉㋊㋋㏠㏡㏢㏣㏤㏥㏦㏧㏨㏩㏪㏫㏬㏭㏮㏯㏰㏱㏲㏳㏴㏵㏶㏷㏸㏹㏺㏻㏼㏽㏾㍙㍚㍛㍜㍝㍞㍟㍠㍡㍢㍣㍤㍥㍦㍧㍨㍩㍪㍫㍬㍭㍮㍯㍰㍘♠♣♧♡♥❤❥❣♂♀✲☀☼☾☽◐◑☺☻☎☏✿❀№↑↓←→√×÷★℃℉°◆◇⊙■□△▽¿½☯✡㍿卍卐♂♀✚〓㎡♪♫♩♬㊚㊛囍㊒㊖Φ♀♂‖$@*&#※卍卐Ψ♫♬♭♩♪♯♮⌒¶∮‖€￡¥$①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳⓪❶❷❸❹❺❻❼❽❾❿⓫⓬⓭⓮⓯⓰⓱⓲⓳⓴㊀㊁㊂㊃㊄㊅㊆㊇㊈㊉㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩⑴⑵⑶⑷⑸⑹⑺⑻⑼⑽⑾⑿⒀⒁⒂⒃⒄⒅⒆⒇⒈⒉⒊⒋⒌⒍⒎⒏⒐⒑⒒⒓⒔⒕⒖⒗⒘⒙⒚⒛ⅠⅡⅢⅣⅤⅥⅦⅧⅨⅩⅪⅫⅰⅱⅲⅳⅴⅵⅶⅷⅸⅹⒶⒷⒸⒹⒺⒻⒼⒽⒾⒿⓀⓁⓂⓃⓄⓅⓆⓇⓈⓉⓊⓋⓌⓍⓎⓏⓐⓑⓒⓓⓔⓕⓖⓗⓘⓙⓚⓛⓜⓝⓞⓟⓠⓡⓢⓣⓤⓥⓦⓧⓨⓩ⒜⒝⒞⒟⒠⒡⒢⒣⒤⒥⒦⒧⒨⒩⒪⒫⒬⒭⒮⒯⒰⒱⒲⒳⒴⒵﹢﹣×÷±/=≌∽≦≧≒﹤﹥≈≡≠=≤≥<>≮≯∷∶∫∮∝∞∧∨∑∏∪∩∈∵∴⊥∥∠⌒⊙√∟⊿㏒㏑%‰⅟½⅓⅕⅙⅛⅔⅖⅚⅜¾⅗⅝⅞⅘≂≃≄≅≆≇≈≉≊≋≌≍≎≏≐≑≒≓≔≕≖≗≘≙≚≛≜≝≞≟≠≡≢≣≤≥≦≧≨≩⊰⊱⋛⋚∫∬∭∮∯∰∱∲∳%℅‰‱øØπ\r\n\r\n♥❣ღ♠♡♤❤❥。，、＇：∶；?‘’“”〝〞ˆˇ﹕︰﹔﹖﹑•¨….¸;！´？！～—ˉ｜‖＂〃｀@﹫¡¿﹏﹋﹌︴々﹟#﹩$﹠&﹪%*﹡﹢﹦﹤‐￣¯―﹨ˆ˜﹍﹎+=<＿_-\\ˇ~﹉﹊（）〈〉‹›﹛﹜『』〖〗［］《》〔〕{}「」【】︵︷︿︹︽_﹁﹃︻︶︸﹀︺︾ˉ﹂﹄︼❝❞°′″＄￥〒￠￡％＠℃℉﹩﹪‰﹫㎡㏕㎜㎝㎞㏎m³㎎㎏㏄º○¤%$º¹²³€£Ұ₴$₰¢₤¥₳₲₪₵元₣₱฿¤₡₮₭₩ރ円₢₥₫₦zł﷼₠₧₯₨Kčर₹ƒ₸￠↑↓←→↖↗↘↙↔↕➻➼➽➸➳➺➻➴➵➶➷➹▶►▷◁◀◄«»➩➪➫➬➭➮➯➱⏎➲➾➔➘➙➚➛➜➝➞➟➠➡➢➣➤➥➦➧➨↚↛↜↝↞↟↠↠↡↢↣↤↤↥↦↧↨⇄⇅⇆⇇⇈⇉⇊⇋⇌⇍⇎⇏⇐⇑⇒⇓⇔⇖⇗⇘⇙⇜↩↪↫↬↭↮↯↰↱↲↳↴↵↶↷↸↹☇☈↼↽↾↿⇀⇁⇂⇃⇞⇟⇠⇡⇢⇣⇤⇥⇦⇧⇨⇩⇪↺↻⇚⇛♐\r\n✐✎✏✑✒✍✉✁✂✃✄✆✉☎☏☑✓✔√☐☒✗✘ㄨ✕✖✖☢☠☣✈★☆✡囍㍿☯☰☲☱☴☵☶☳☷☜☞☝✍☚☛☟✌♤♧♡♢♠♣♥♦☀☁☂❄☃♨웃유❖☽☾☪✿♂♀✪✯☭➳卍卐√×■◆●○◐◑✙☺☻❀⚘♔♕♖♗♘♙♚♛♜♝♞♟♧♡♂♀♠♣♥❤☜☞☎☏⊙◎☺☻☼▧▨♨◐◑↔↕▪▒◊◦▣▤▥▦▩◘◈◇♬♪♩♭♪の★☆→あぃ￡Ю〓§♤♥▶¤✲❈✿✲❈➹☀☂☁【】┱┲❣✚✪✣✤✥✦❉❥❦❧❃❂❁❀✄☪☣☢☠☭ღ▶▷◀◁☀☁☂☃☄★☆☇☈⊙☊☋☌☍ⓛⓞⓥⓔ╬『』∴☀♫♬♩♭♪☆∷﹌の★◎▶☺☻►◄▧▨♨◐◑↔↕↘▀▄█▌◦☼♪の☆→♧ぃ￡❤▒▬♦◊◦♠♣▣۰•❤•۰►◄▧▨♨◐◑↔↕▪▫☼♦⊙●○①⊕◎Θ⊙¤㊣★☆♀◆◇◣◢◥▲▼△▽⊿◤◥✐✌✍✡✓✔✕✖♂♀♥♡☜☞☎☏⊙◎☺☻►◄▧▨♨◐◑↔↕♥♡▪▫☼♦▀▄█▌\r\n▐░▒▬♦◊◘◙◦☼♠♣▣▤▥▦▩◘◙◈♫♬♪♩♭♪✄☪☣☢☠♯♩♪♫♬♭♮☎☏☪♈ºº₪¤큐«»™♂✿♥　◕‿-｡　｡◕‿◕｡\r\nΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζνξοπρσηθικλμτυφχψω\r\nАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя\r\nāáǎàōóǒòēéěèīíǐìūúǔùǖǘǚǜüêɑńňɡㄅㄆㄇㄈㄉㄊㄋㄌㄍㄎㄏㄐㄑㄒㄓㄔㄕㄖㄗㄘㄙㄚㄛㄜㄝㄞㄟㄠㄡㄢㄣㄤㄥㄦㄧㄨㄩ\r\nぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔゕゖァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺ・ーヽヾヿ゠ㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇺㇻㇼㇽㇾㇿ─ ━│┃╌╍╎╏┄ ┅┆┇┈ ┉┊┋┌┍┎┏┐┑┒┓└ ┕┖┗ ┘┙┚┛├┝┞┟┠┡┢┣ ┤┥┦┧┨┩┪┫┬ ┭ ┮ ┯ ┰ ┱ ┲ ┳ ┴ ┵ ┶ ┷ ┸ ┹ ┺ ┻┼ ┽ ┾ ┿ ╀ ╁ ╂ ╃ ╄ ╅ ╆ ╇ ╈ ╉ ╊ ╋ ╪ ╫ ╬═║╒╓╔ ╕╖╗╘╙╚ ╛╜╝╞╟╠ ╡╢╣╤ ╥ ╦ ╧ ╨ ╩ ╳╔ ╗╝╚ ╬ ═ ╓ ╩ ┠ ┨┯ ┷┏ ┓┗ ┛┳ ⊥ ﹃ ﹄┌ ╮ ╭ ╯╰\r\n♚　♛　♝　♞　♜　♟　♔　♕　♗　♘　♖　♟. 。 ， 、 ; ： ？ ! ˉ ˇ ¨ ~ 々 ‖ ∶ \" ' ` | · … — ～ - 〃 ‘ ’ “ ” 〝 〞 〔 〕 〈 〉 《 》 「 」 『 』 〖 〗 【 】 ( ) [ ] { ｝ ︻ ︼ ﹄ ﹃+ - × ÷ ± / ≌ ∽ ≦ ≧ ≒ ﹤ ﹥ ≈ ≡ ≠ = ≤ ≥ < > ≮ ≯ ∷ ∶ ∫ ∮ ∝ ∞ ∧ ∨ ∑ ∏ ∪ ∩ ∈ ∵ ∴ ⊥ ∥ ∠ ⌒ ⊙ √ ∟ ⊿ ㏒ ㏑ % ‰丶";

 

            var arr = oldstr.ToArray();
            oldstr = "";
            for (int i = 0; i < arr.Length; i++)
            {
                var item = arr[i].ToString();
                //Console.WriteLine(item);
                if (te.Contains(item) == false)
                { 
                    oldstr = oldstr + item;
                }
            }


            return oldstr;

        }


        //传值[0,2] 返回指定某元素,失败返回默认配置值
        public static int rangeStringReturnindexobj(string Range, int index, int intdefault)
        {

            try
            {
                var a = Range.Replace("[", "").Replace("]", "").Trim();



                if (a.IsContainsIn(","))
                {
                    var arr = a.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2)
                    {

                        return Convert.ToInt32(arr[index]);
                    }
                }

            }
            catch (Exception ex)
            {
                var exErr = string.Format("异常包: [{0}] [{1}] 异常消息:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);
            }
            finally
            {
            }

            return intdefault;
        }

        //取文本前半部分,条件是字符串尾部关键词最后一个匹配前部分字符串
        public static string getstringLastIndexOf(string inputValue, string LastIndexKeyword)
        {
            var last = inputValue.LastIndexOf(LastIndexKeyword);

            if (last > 0 && inputValue.IsNullOrEmpty() == false)
            {
                return inputValue.Substring(0, last);
            }

            return inputValue;
        }

        //取文本前半部分,条件是字符串 关键词第一个出现开始前面的字符串
        public static string getstringIndexOf(string inputValue, string IndexKeyword)
        {
            var index = inputValue.IndexOf(IndexKeyword);

            if (index > 0 && inputValue.IsNullOrEmpty() == false)
            {
                return inputValue.Substring(0, index);
            }

            return inputValue;
        }


        //取文本后半部分,条件是字符串尾部关键词最后一个匹配后部分字符串,包含查找关键词
        public static string getstringLastSectionLastIndexOf_includekeyword(string inputValue, string LastIndexKeyword)
        {
            var last = inputValue.LastIndexOf(LastIndexKeyword);

            if (last > 0 && inputValue.IsNullOrEmpty() == false)
            {
                return inputValue.Substring(last, inputValue.Length - last);
            }

            return inputValue;
        }

        //取文本后半部分,条件是字符串尾部关键词最后一个匹配后部分字符串,不包含查找关键词
        public static string getstringLastSectionLastIndexOf_Notincludekeyword(string inputValue, string LastIndexKeyword)
        {
            var last = inputValue.LastIndexOf(LastIndexKeyword);

            if (last > 0 && inputValue.IsNullOrEmpty() == false)
            {
                return inputValue.Substring(last + LastIndexKeyword.Length, inputValue.Length - last - LastIndexKeyword.Length);
            }

            return inputValue;
        }


        //替换字符串（文字），仅替换第1次出现的
        public static string ReplaceOnlyThefirstOccurrence_Regex(string s, string keyword, string tiHuanValue)
        {

            Regex r = new Regex(keyword);
            s = r.Replace(s, tiHuanValue, 1);

            return s;
        }
        public static string ReplaceOnlyThefirstOccurrence_Findindex(string s, string keyword, string tiHuanValue)
        {
            if (s.IsNullOrEmpty() == false)
            {

                var index = s.IndexOf(keyword);
                if (index >= 0)
                {
                    var beforepart = s.Substring(0, index);
                    var afterpart = s.Substring(index + keyword.Length, s.Length - index - keyword.Length);

                    return beforepart + tiHuanValue + afterpart;

                }

            }


            return s;
        }

        //替换所有
        public static string Replace_all(string tiHuanValue, string oldstring, params string[] listkeys)
        {
            for (int i = 0; i < listkeys.Length; i++)
            {
                oldstring = oldstring.Replace(listkeys[i], tiHuanValue);
            }


            return oldstring;
        }

        //字符串中含有中文个数
        public static int GetChineseCharactersCount(string socure)
        {
            var count = 0;
            CharEnumerator CEnumerator = socure.GetEnumerator();
            Regex regex = new Regex("^[\u4E00-\u9FA5]{0,}$");
            while (CEnumerator.MoveNext())
            {
                if (regex.IsMatch(CEnumerator.Current.ToString(), 0))
                {
                    count++;
                }
            }

            return count;

        }

    }
    public class random
    {
        ///<summary>
        ///生成随机字符串
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            //Random r = new Random(BitConverter.ToInt32(b, 0));
            Random r = new Random(GetRandomSeed());
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }

            return s;
        }


        public static string GetRandomString(int min, int max, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            var rid = CsharpLazycode.Module.Laycode.random.NextIncludeMax(min, max);

            return CsharpLazycode.Module.Laycode.random.GetRandomString(rid, useNum, useLow, useUpp, useSpe, custom);
        }


        //获取随机种子
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        //传值(0,2)返回0-1包含1之间的数
        public static int Next(int minValue, int maxValue)
        {
            Random rd = new Random(GetRandomSeed());
            var id = rd.Next(minValue, maxValue);
            //Console.WriteLine(id);


            return id;

        }
        //传值(0,2)返回0-2包含2之间的数
        public static int NextIncludeMax(int minValue, int maxValue)
        {
            Random rd = new Random(GetRandomSeed());
            var id = rd.Next(minValue, maxValue + 1);
            //Console.WriteLine(id);
            return id;

        }
        //传值[0,2]返回0-2包含2之间的数,如果解析异常,返回默认配置值
        public static int NextIncludeMax(string Range, int intdefault)
        {

            try
            {
                var a = Range.Replace("[", "").Replace("]", "").Trim();



                if (a.IsContainsIn(","))
                {
                    var arr = a.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2)
                    {
                        int minValue = Convert.ToInt32(arr[0]);
                        int maxValue = Convert.ToInt32(arr[1]);
                        Random rd = new Random(GetRandomSeed());
                        var id = rd.Next(minValue, maxValue + 1);
                        //Console.WriteLine(id);
                        return id;
                    }
                }

            }
            catch (Exception ex)
            {
                var exErr = string.Format("异常包: [{0}] [{1}] 异常消息:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);
            }
            finally
            {
            }

            return intdefault;
        }

    }

    public class sys
    {

        #region [StructLayout] [Message]
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWnd;
            public UInt32 msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public UInt32 time;
            public Point p;
        }
        #endregion


        #region M_MOUSEEVENTF_MOVE_常量
        public class M_MOUSEEVENTF_MOVE_常量
        {
            //移动鼠标 
            public const int MOUSEEVENTF_MOVE = 0x0001;
            //模拟鼠标左键按下 
            public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            public const uint LeftDown = 0x0002;

            //模拟鼠标左键抬起 
            public const int MOUSEEVENTF_LEFTUP = 0x0004;
            //模拟鼠标右键按下 
            public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            //模拟鼠标右键抬起 
            public const int MOUSEEVENTF_RIGHTUP = 0x0010;
            //模拟鼠标中键按下 
            public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            //模拟鼠标中键抬起 
            public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
            //标示是否采用绝对坐标 
            public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

            public const int BM_GETCHECK = 0x00F0;
            public const int BM_SETCHECK = 0x00F1;
            public const int BM_GETSTATE = 0x00F2;
            public const int BM_SETSTATE = 0x00F3;
            public const int BM_SETSTYLE = 0x00F4;
            public const int BM_CLICK = 0x00F5;
            public const int BM_GETIMAGE = 0x00F6;
            public const int BM_SETIMAGE = 0x00F7;

            public const int WM_LBUTTONDOWN = 513;//按下鼠标左键
            public const int WM_LBUTTONUP = 514;//释放鼠标左键


            //Windows 使用的256个虚拟键码	
            public const int VK_LBUTTON = 0x1;
            public const int VK_RBUTTON = 0x2;
            public const int VK_CANCEL = 0x3;
            public const int VK_MBUTTON = 0x4;
            public const int VK_BACK = 0x8;
            public const int VK_TAB = 0x9;
            public const int VK_CLEAR = 0xC;
            public const int VK_RETURN = 0xD;
            public const int VK_SHIFT = 0x10;
            public const int VK_CONTROL = 0x11;
            public const int VK_MENU = 0x12;
            public const int VK_PAUSE = 0x13;
            public const int VK_CAPITAL = 0x14;
            public const int VK_ESCAPE = 0x1B;
            public const int VK_SPACE = 0x20;
            public const int VK_PRIOR = 0x21;
            public const int VK_NEXT = 0x22;
            public const int VK_END = 0x23;
            public const int VK_HOME = 0x24;
            public const int VK_LEFT = 0x25;
            public const int VK_UP = 0x26;
            public const int VK_RIGHT = 0x27;
            public const int VK_DOWN = 0x28;
            public const int VK_Select = 0x29;
            public const int VK_PRINT = 0x2A;
            public const int VK_EXECUTE = 0x2B;
            public const int VK_SNAPSHOT = 0x2C;
            public const int VK_Insert = 0x2D;
            public const int VK_Delete = 0x2E;
            public const int VK_HELP = 0x2F;
            public const int VK_0 = 0x30;
            public const int VK_1 = 0x31;
            public const int VK_2 = 0x32;
            public const int VK_3 = 0x33;
            public const int VK_4 = 0x34;
            public const int VK_5 = 0x35;
            public const int VK_6 = 0x36;
            public const int VK_7 = 0x37;
            public const int VK_8 = 0x38;
            public const int VK_9 = 0x39;
            public const int VK_A = 0x41;
            public const int VK_B = 0x42;
            public const int VK_C = 0x43;
            public const int VK_D = 0x44;
            public const int VK_E = 0x45;
            public const int VK_F = 0x46;
            public const int VK_G = 0x47;
            public const int VK_H = 0x48;
            public const int VK_I = 0x49;
            public const int VK_J = 0x4A;
            public const int VK_K = 0x4B;
            public const int VK_L = 0x4C;
            public const int VK_M = 0x4D;
            public const int VK_N = 0x4E;
            public const int VK_O = 0x4F;
            public const int VK_P = 0x50;
            public const int VK_Q = 0x51;
            public const int VK_R = 0x52;
            public const int VK_S = 0x53;
            public const int VK_T = 0x54;
            public const int VK_U = 0x55;
            public const int VK_V = 0x56;
            public const int VK_W = 0x57;
            public const int VK_X = 0x58;
            public const int VK_Y = 0x59;
            public const int VK_Z = 0x5A;
            public const int VK_STARTKEY = 0x5B;
            public const int VK_CONTEXTKEY = 0x5D;
            public const int VK_NUMPAD0 = 0x60;
            public const int VK_NUMPAD1 = 0x61;
            public const int VK_NUMPAD2 = 0x62;
            public const int VK_NUMPAD3 = 0x63;
            public const int VK_NUMPAD4 = 0x64;
            public const int VK_NUMPAD5 = 0x65;
            public const int VK_NUMPAD6 = 0x66;
            public const int VK_NUMPAD7 = 0x67;
            public const int VK_NUMPAD8 = 0x68;
            public const int VK_NUMPAD9 = 0x69;
            public const int VK_MULTIPLY = 0x6A;
            public const int VK_ADD = 0x6B;
            public const int VK_SEPARATOR = 0x6C;
            public const int VK_SUBTRACT = 0x6D;
            public const int VK_DECIMAL = 0x6E;
            public const int VK_DIVIDE = 0x6F;
            public const int VK_F1 = 0x70;
            public const int VK_F2 = 0x71;
            public const int VK_F3 = 0x72;
            public const int VK_F4 = 0x73;
            public const int VK_F5 = 0x74;
            public const int VK_F6 = 0x75;
            public const int VK_F7 = 0x76;
            public const int VK_F8 = 0x77;
            public const int VK_F9 = 0x78;
            public const int VK_F10 = 0x79;
            public const int VK_F11 = 0x7A;
            public const int VK_F12 = 0x7B;
            public const int VK_F13 = 0x7C;
            public const int VK_F14 = 0x7D;
            public const int VK_F15 = 0x7E;
            public const int VK_F16 = 0x7F;
            public const int VK_F17 = 0x80;
            public const int VK_F18 = 0x81;
            public const int VK_F19 = 0x82;
            public const int VK_F20 = 0x83;
            public const int VK_F21 = 0x84;
            public const int VK_F22 = 0x85;
            public const int VK_F23 = 0x86;
            public const int VK_F24 = 0x87;
            public const int VK_NUMLOCK = 0x90;
            public const int VK_OEM_SCROLL = 0x91;
            public const int VK_OEM_1 = 0xBA;
            public const int VK_OEM_PLUS = 0xBB;
            public const int VK_OEM_COMMA = 0xBC;
            public const int VK_OEM_MINUS = 0xBD;
            public const int VK_OEM_PERIOD = 0xBE;
            public const int VK_OEM_2 = 0xBF;
            public const int VK_OEM_3 = 0xC0;
            public const int VK_OEM_4 = 0xDB;
            public const int VK_OEM_5 = 0xDC;
            public const int VK_OEM_6 = 0xDD;
            public const int VK_OEM_7 = 0xDE;
            public const int VK_OEM_8 = 0xDF;
            public const int VK_ICO_F17 = 0xE0;
            public const int VK_ICO_F18 = 0xE1;
            public const int VK_OEM102 = 0xE2;
            public const int VK_ICO_HELP = 0xE3;
            public const int VK_ICO_00 = 0xE4;
            public const int VK_ICO_CLEAR = 0xE6;
            public const int VK_OEM_RESET = 0xE9;
            public const int VK_OEM_JUMP = 0xEA;
            public const int VK_OEM_PA1 = 0xEB;
            public const int VK_OEM_PA2 = 0xEC;
            public const int VK_OEM_PA3 = 0xED;
            public const int VK_OEM_WSCTRL = 0xEE;
            public const int VK_OEM_CUSEL = 0xEF;
            public const int VK_OEM_ATTN = 0xF0;
            public const int VK_OEM_FINNISH = 0xF1;
            public const int VK_OEM_COPY = 0xF2;
            public const int VK_OEM_AUTO = 0xF3;
            public const int VK_OEM_ENLW = 0xF4;
            public const int VK_OEM_BACKTAB = 0xF5;
            public const int VK_ATTN = 0xF6;
            public const int VK_CRSEL = 0xF7;
            public const int VK_EXSEL = 0xF8;
            public const int VK_EREOF = 0xF9;
            public const int VK_PLAY = 0xFA;
            public const int VK_ZOOM = 0xFB;
            public const int VK_NONAME = 0xFC;
            public const int VK_PA1 = 0xFD;
            public const int VK_OEM_CLEAR = 0xFE;


        }
        #endregion


        #region Windows_常量
        public class M_Windows_常量
        {
            public const int GW_CHILD = 5;
            public const int GW_HWNDNEXT = 2;

        }
        #endregion

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int PeekMessage(out Message msg, int hWnd, int messageFilterMin, int messageFilterMax, int flags);

        public static void Delay(int ms)
        {
            int Time = Environment.TickCount + ms;
            //Message Msg;
            do
            {
                if (PeekMessage(out Message Msg, 0, 0, 0, 0) == 0)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }

            while (Environment.TickCount < Time);
        }
        public static void Delaytest(int milliSecond)
        {

            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
            }
        }

        #region 等待延时
        [STAThread]
        /// <summary>
        /// 等待延时
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="breakBool">控制等待延时部分跳出循环 假的时候跳出</param>
        public static void WaitDelay(int ms, bool breakBool)
        {
            int Time = Environment.TickCount + ms;
            //Message Msg;
            do
            {
                if (PeekMessage(out Message Msg, 0, 0, 0, 0) == 0)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                if (breakBool == false) { break; }

            }

            while (Environment.TickCount < Time);

        }



        #endregion
        #region 等待延时 [Bool]
        /// <summary>
        /// 等待延时
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="breakBool">控制等待延时部分跳出循环 假的时候跳出</param>
        public static bool WaitDelaybool(int ms, bool breakBool)
        {
            int Time = Environment.TickCount + ms;
            //Message Msg;
            do
            {
                if (PeekMessage(out Message Msg, 0, 0, 0, 0) == 0)
                {
                    Thread.Sleep(1);
                }
                else
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                if (breakBool == false) { break; }

            }

            while (Environment.TickCount < Time);
            return true;
        }



        #endregion
    }

    public class img
    {
        //参数是图片的路径
        public static byte[] GetPictureData(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }
        //将Image转换成流数据，并保存为byte[]
        public static byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }
        public static System.Drawing.Image ReturnPhoto(byte[] streamByte)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }
        public void WritePhoto(byte[] streamByte)
        {
            // Response.ContentType 的默认值为默认值为“text/html”
            //Response.ContentType = "image/GIF";
            //图片输出的类型有: image/GIF     image/JPEG
            //Response.BinaryWrite(streamByte);
        }
    }

    public class Decimal
    {
        //计算百分比 四舍五入,精确2位 x100结果%
        public static string CalculateThepercentage(decimal A, decimal B, string baoliuXiaoshudianShu = "0.0000")
        {
            //计算比率
            decimal t = decimal.Parse((A / B).ToString(baoliuXiaoshudianShu)); //保留4位小数            //
            var t1 = Math.Round(t, 2);  //四舍五入,精确2位
            var t2 = t1 * 100;  //乘以100     x100结果%             
            return t2.ToString("0.00");
        }
        //计算百分比 不四舍五入 x100结果%
        public static string CalculateThepercentageNosishewuru(decimal A, decimal B, string baoliuXiaoshudianShu = "0.0000")
        {
            //计算比率
            decimal t = decimal.Parse((A / B).ToString(baoliuXiaoshudianShu)); //保留4位小数  
            var t2 = t * 100;  //乘以100     x100结果%             
            return t2.ToString("0.00");
        }


    }

}



