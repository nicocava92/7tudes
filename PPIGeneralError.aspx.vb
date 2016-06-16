
Partial Class PPIGeneralError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Server.ClearError()
        Catch

        End Try

        Dim ErrMsgTxt As String

        If Request.Cookies("LanguageID") Is Nothing Then ' No language cookie. Show English by Default
            ErrMsgTxt = "<h1>Site Error</h1>"
            ErrMsgTxt += "<p>There is an error with this page. The issue may be temporary. Please try refreshing the page.</p>"
            ErrMsgTxt += "<p>If this did not correct the error please <a href=mailto:surveys@perfprog.com>contact us</a> with your issue. Please include as many details as possible (what you did prior to receiving the error, your browser version, etc).</p>"
            ErrMsgTxt += "<p>We apologize for the inconvenience.</p>"
        Else
            Select Case Request.Cookies("LanguageID").Value
                Case 1 ' English
                    ErrMsgTxt = "<h1>Site Error</h1>"
                    ErrMsgTxt += "<p>There is an error with this page. The issue may be temporary. Please try refreshing the page.</p>"
                    ErrMsgTxt += "<p>If this did not correct the error please <a href=mailto:surveys@perfprog.com>contact us</a> with your issue. Please include as many details as possible (what you did prior to receiving the error, your browser version, etc).</p>"
                    ErrMsgTxt += "<p>We apologize for the inconvenience.</p>"
                Case 3 ' Charlotte
                    ErrMsgTxt = "<h1>webstedet Fejl</h1>"
                    ErrMsgTxt += "<p>Der er en fejl med denne side . Spørgsmålet kan være midlertidig . Prøv at opdatere siden.</p>"
                    ErrMsgTxt += "<p>Hvis dette ikke rette fejlen skal du <a href=mailto:surveys@perfprog.com>kontakte os</a> med dit problem . Vedlæg så mange detaljer som muligt ( hvad du gjorde før modtagelsen fejlen , din browserversion , osv).</p>"
                    ErrMsgTxt += "<p>Vi beklager ulejligheden.</p>"
                Case 4 ' Spanish
                    ErrMsgTxt = "<h1>Error del Sitio</h1>"
                    ErrMsgTxt += "<p>Hay un error en esta página . El problema puede ser temporal . Por favor, intenta actualizar la página.</p>"
                    ErrMsgTxt += "<p>Si esto no se corrige el error <a href=mailto:surveys@perfprog.com>contáctanos</a> con su problema . Por favor, incluya tantos detalles como sea posible ( lo que hiciste antes de recibir el error , la versión del navegador , etc ).</p>"
                    ErrMsgTxt += "<p>Pedimos disculpas por las molestias.</p>"
                Case 5 ' French
                    ErrMsgTxt = "<h1>site erreur</h1>"
                    ErrMsgTxt += "<p>Il ya une erreur avec cette page . La question peut être temporaire . Se il vous plaît essayez de rafraîchir la page.</p>"
                    ErrMsgTxt += "<p>Si cela n'a pas corriger l'erreur se il vous plaît <a href=mailto:surveys@perfprog.com>contactez-nous</a> avec votre question . Se il vous plaît inclure autant de détails que possible (ce que vous avez fait avant de recevoir l'erreur , la version du navigateur de votre , etc).</p>"
                    ErrMsgTxt += "<p>Nous nous excusons pour la gêne occasionnée.</p>"
                Case 6 ' Japanese
                    ErrMsgTxt = "<h1>サイトエラー</h1>"
                    ErrMsgTxt += "<p>このページにエラーがあります。問題が一時的な場合があります。ページをリフレッシュしてみてください</p>"
                    ErrMsgTxt += "<p>このエラーを修正しなかった場合は <a href=mailto:surveys@perfprog.com>があなたの問題に問い合わせ</a>ください。 （エラー、お使いのブラウザのバージョンなどを受信する前に何をしたか） 、できるだけ多くの詳細を記載してください。</p>"
                    ErrMsgTxt += "<p>ご不便をおかけして申し訳ございません</p>"
                Case 7 ' Portuguese
                    ErrMsgTxt = "<h1>Erro do Site</h1>"
                    ErrMsgTxt += "<p>Há um erro com esta página. O problema pode ser temporário. Por favor, tente atualizar a página.</p>"
                    ErrMsgTxt += "<p>Se isso não corrigir o erro <a href=mailto:surveys@perfprog.com>contato conosc </a> com o seu problema. Por favor inclua o máximo de detalhes possível (o que você fez antes de receber o erro, a versão do navegador , etc).</p>"
                    ErrMsgTxt += "<p>Pedimos desculpas pelo inconveniente.</p>"
                Case 9 ' Dutch
                    ErrMsgTxt = "<h1>Site Error</h1>"
                    ErrMsgTxt += "<p>Er is een fout bij deze pagina . Het probleem kan tijdelijk zijn . Probeer de pagina te vernieuwen .</p>"
                    ErrMsgTxt += "<p>Als dit het probleem niet verhelpen <a href=mailto:surveys@perfprog.com>contact met ons</a> met uw probleem. Vermeld dan zo veel mogelijk details (wat je voorafgaand aan de ontvangst van de fout , je browser versie , etc deed).</p>"
                    ErrMsgTxt += "<p>Onze excuses voor het ongemak.</p>"
                Case 10 ' German
                    ErrMsgTxt = "<h1>Website- Fehler</h1>"
                    ErrMsgTxt += "<p>Es ist ein Fehler für diese Seite. Das Problem kann nur vorübergehend sein. Bitte versuchen Sie die Seite aktualisieren.</p>"
                    ErrMsgTxt += "<p>Wenn dies nicht den Fehler zu korrigieren <a href=mailto:surveys@perfprog.com>kontaktieren Sie uns</a> mit Ihrem Problem . Bitte geben Sie so viele Details wie möglich (was Sie vor Erhalt der Fehler , Browserversion , etc. haben).</p>"
                    ErrMsgTxt += "<p>Wir entschuldigen uns für die Unannehmlichkeiten.</p>"
                Case 11 ' Chinese
                    ErrMsgTxt = "<h1>网站错误</h1>"
                    ErrMsgTxt += "<p>有一个与此页错误。这个问题可能是暂时的。请尝试刷新页面。</p>"
                    ErrMsgTxt += "<p>如果这没有纠正错误，请<a href=mailto:surveys@perfprog.com>与我们联系</a> 您的问题。请提供尽可能多的细节尽可能（你之前收到错误，您的浏览器版本，等干了什么）。</p>"
                    ErrMsgTxt += "<p>我们对不便表示抱歉</p>"
                Case 12 ' Korean
                    ErrMsgTxt = "<h1>사이트 오류</h1>"
                    ErrMsgTxt += "<p>이 페이지 에 오류가 있습니다 . 문제는 일시적 일 수 있습니다. 페이지를 새로 고침 해보세요.</p>"
                    ErrMsgTxt += "<p>이 오류를 수정 하지 않은 경우 href=mailto:surveys@perfprog.com> 이 문제를 문의 </a> 하시기 바랍니다. ( 오류 , 브라우저 버전 등 을 수신 하기 전에 무슨 짓을 ) 가능한 한 많은 세부 사항을 기입하십시오.</p>"
                    ErrMsgTxt += "<p>불편을 끼쳐 드려 죄송합니다.</p>"
                Case 13 ' Italian
                    ErrMsgTxt = "<h1>Errore del sito</h1>"
                    ErrMsgTxt += "<p>C'è un errore di questa pagina. Il problema può essere temporaneo. Prova ad aggiornare la pagina.</p>"
                    ErrMsgTxt += "<p>Se questo non ha corretto l'errore <a href=mailto:surveys@perfprog.com>contattaci</a> con il vostro problema. Si prega di includere il maggior numero di dettagli possibile (quello che hai fatto prima di ricevere la , la versione del browser , ecc errore).</p>"
                    ErrMsgTxt += "<p>Ci scusiamo per l'inconveniente.</p>"
                Case Else 'Else, Show English
                    ErrMsgTxt = "<h1>Site Error</h1>"
                    ErrMsgTxt += "<p>There is an error with this page. The issue may be temporary. Please try refreshing the page.</p>"
                    ErrMsgTxt += "<p>If this did not correct the error please <a href=mailto:surveys@perfprog.com>contact us</a> with your issue. Please include as many details as possible (what you did prior to receiving the error, your browser version, etc).</p>"
                    ErrMsgTxt += "<p>We apologize for the inconvenience.</p>"
            End Select

        End If

        Me.show_error_message.Text = ErrMsgTxt

    End Sub
End Class
