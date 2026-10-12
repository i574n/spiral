program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: Boolean;
  v11: Boolean;
  v10: Boolean;
begin
  v0 := 4;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 10;
  v1[1] := 20;
  v1[2] := 30;
  v2 := v1[0];
  v3 := v1[1];
  v4 := v2 + v3;
  v1[3] := v4;
  v5 := v1[2];
  v6 := v1[3];
  v7 := v5 + v6;
  v8 := LongInt(Length(v1));
  v9 := v8 = v0;
  if v9 then begin
      v10 := v7 = 60;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
