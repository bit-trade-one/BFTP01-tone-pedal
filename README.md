# tone-pedal


開発環境について
Visual C# 2008 Express
（最新版のVisual StudioでもソースをインポートすればOKだと思います。）


ファイル構成について

FW_Circuitフォルダ
FW_v105_TonePedal
effect-pedal_20150424_sch.pdf（回路図）

Configuration_toolフォルダ
PC_ver101_20150626


ファームウェアの書き換え手順


１.ブートモードにする

ブートモードの入り方
USBをつなげた状態で、TONE１のSWを１と２の間にしてLEDが点滅する状態に、TONE２のSWを３と４の間にしてLEDが点滅する状態にする、その状態でUSBケーブルを抜く。
トーンペダルのデバイスがリムーブされたあとに、USBケーブルを挿すと、HIDブートローダデバイスとして認識される。

２．HEXを書き込む。

３．SWを１〜４のいずれかにして、USBケーブルを指し直す。





