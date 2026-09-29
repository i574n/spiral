program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
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
  v2: LongInt;
  v3: Boolean;
  v4: Boolean;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 0;
  v1 := 0;
  while method0 do begin
      v2 := v0 + 1;
      v0 := v2;
      v3 := v0 < 3;
      if v3 then begin
          continue;
      end else begin
          v4 := v0 >= 6;
          if v4 then begin
              break;
          end else begin
              v5 := v1 + v0;
              v1 := v5;
          end;
      end;
  end;
  v6 := v1 - 12;
  Result := v6;
end;
begin
  Halt(SpiralMain);
end.
