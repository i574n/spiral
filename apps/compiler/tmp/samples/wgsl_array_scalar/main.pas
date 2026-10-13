program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TArray0 = array of LongInt;
  TArray1 = array of Boolean;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: LongInt;
  v3: LongInt;
  v4: TArray1;
  tmp6: TArray1;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v11: LongInt;
  v12: Boolean;
  v15: LongInt;
  v13: Boolean;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
begin
  v0 := 5;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v1[0] := 0;
  v1[1] := 1;
  v1[2] := 4;
  v2 := 3;
  v1[v2] := 9;
  v3 := v2 + 1;
  v1[v3] := 16;
  tmp6 := nil;
  SetLength(tmp6, 3);
  v4 := tmp6;
  v4[0] := False;
  v4[1] := True;
  v4[2] := False;
  v5 := v1[1];
  v6 := v1[2];
  v7 := v5 + v6;
  v8 := v1[3];
  v9 := v7 + v8;
  v10 := v1[4];
  v11 := v9 + v10;
  v12 := v4[1];
  if v12 then begin
      v13 := v4[0];
      if v13 then begin
          v15 := 0;
      end else begin
          v15 := 100;
      end;
  end else begin
      v15 := 0;
  end;
  v16 := v11 + v15;
  v17 := LongInt(Length(v1));
  v18 := v16 + v17;
  Result := v18;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
