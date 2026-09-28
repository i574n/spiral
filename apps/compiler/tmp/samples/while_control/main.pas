program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function method0: Boolean; forward;
function method0: Boolean;
begin
  Result := True;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v3: LongInt;
  v4: Boolean;
  v5: Boolean;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 0;
  v1 := 0;
  while method0 do begin
      v3 := v0 + 1;
      v0 = v3;
      v4 := v0 < 3;
      if v4 then begin
          continue;
      end else begin
          v5 := v0 >= 6;
          if v5 then begin
              break;
          end else begin
              v6 := v1 + v0;
              v1 = v6;
          end;
      end;
  end;
  v7 := v1 - 12;
  Result := v7;
end;
begin
  Halt(SpiralMain);
end.
