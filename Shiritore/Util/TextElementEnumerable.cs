using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritore.Util
{
    /// <summary>
    /// 文字列に対する TextElementEnumerator 列挙子を公開するクラス。
    /// </summary>
    public class TextElementEnumerable : IEnumerable
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="source">列挙対象となる文字列。</param>
        public TextElementEnumerable(string source)
        {
            this.Source = source;
        }

        /// <summary>
        /// 列挙対象文字列を取得する。
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// TextElementEnumerator 列挙子を取得する。
        /// </summary>
        /// <returns>TextElementEnumerator 列挙子。</returns>
        public TextElementEnumerator GetEnumerator()
        {
            return StringInfo.GetTextElementEnumerator(this.Source);
        }

        #region IEnumerable の明示的実装

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}