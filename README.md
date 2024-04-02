# ShooterDemo / Good Mood Games

Proje unity sürümü : 2022.3.22f1

Projeyi indirip "MainScene" sahnesinde direkt olarak çalıştırabilirsiniz. Test ettim herhangi bir problem yoktur.

Keyboard/mouse + gamepad olarak oynanabilir şekilde tasarlanmıştır.

Kullanılan özellikler:

Singleton
Object pooling
Interface

Buglar :

Unity'nin pooling sistemi kurşun atış hızından dolayı bazen yeterince hızlı assign etmediği için kurşun rotasyonunda nadiren de olsa bug olabiliyor(Önceki kurşunun yerine atıyor). 
Manuel olarak object poola alıştığım için unity'nin sistemine tam aşina olamadım açıkçası o yüzden bu bug'ı düzeltemedim.

Yine benzer şekilde unity starter asset camera/mouse hareketlerinde minik takılmalar olabiliyor bir sürü şey test ettim ancak bu bug içinde bir sonuç alamadım.