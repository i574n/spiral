program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function SpiralMain: LongInt;
var
  v0: AnsiChar;
  v1: Boolean;
  v3: Boolean;
  v2: Boolean;
begin
  v0 := 'x';
  v1 := v0 = ' ';
  if v1 then begin
      v3 := True;
  end else begin
      v2 := v0 = '/';
      v3 := v2;
  end;
  if v3 then begin
      Result := 1;
  end else begin
      Result := 0;
  end;
end;
begin
  Halt(SpiralMain);
end.
