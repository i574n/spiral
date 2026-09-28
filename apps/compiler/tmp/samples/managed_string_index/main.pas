program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiChar;
  v2: Boolean;
begin
  v0 := 'qwe';
  v1 := v0[1 + 1];
  v2 := v1 = 'w';
  if v2 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
