program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Int64;
  v2: Byte;
  v3: AnsiString;
begin
  v0 := 60;
  v1 := (-9000000000);
  v2 := 200;
  v3 := 'cube';
  Write(v3, ': ', v0, ' frames, checksum ', 970392, #10);
  Write('big ', v1, ', small ', (-5), ', byte ', v2, #10);
  Write('100% {braces} "quoted" \ tab'#9'end'#10);
  Write('literal', #10);
  Write(v3);
  Write(#10);
  Result := 0;
end;
begin
  Halt(SpiralMain);
end.
