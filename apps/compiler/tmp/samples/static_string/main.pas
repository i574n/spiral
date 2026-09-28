program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function method0(v0: AnsiString): Boolean; forward;
function method0(v0: AnsiString): Boolean;
begin
  Result := True;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: Boolean;
begin
  v0 := 'spiral';
  v1 := method0(v0);
  if v1 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
