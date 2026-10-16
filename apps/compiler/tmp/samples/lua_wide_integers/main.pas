program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function lcg_0(v0: QWord; v1: QWord; v2: LongInt; v3: QWord): QWord; forward;
function lcg_0(v0: QWord; v1: QWord; v2: LongInt; v3: QWord): QWord;
var
  v4: Boolean;
  v5: LongInt;
  v6: QWord;
  v7: QWord;
  tmp4: QWord;
  tmp5: QWord;
  tmp6: LongInt;
  tmp7: QWord;
begin
  while True do begin
      v4 := v2 = 0;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v5 := v2 - 1;
          v6 := v3 * v0;
          v7 := v6 + v1;
          tmp4 := v0;
          tmp5 := v1;
          tmp6 := v5;
          tmp7 := v7;
          v0 := tmp4;
          v1 := tmp5;
          v2 := tmp6;
          v3 := tmp7;
          Continue;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: QWord;
  v1: QWord;
  v2: QWord;
  v3: LongInt;
  v4: QWord;
  v5: Int64;
  v6: Int64;
  v7: QWord;
  v8: Int64;
  v9: QWord;
  v10: Int64;
  v11: Int64;
  v12: Int64;
  v13: Int64;
  v14: Int64;
  v15: QWord;
  v16: QWord;
  v17: Int64;
  v18: QWord;
  v19: Double;
  v20: Int64;
  v21: LongWord;
  v22: Double;
  v23: Boolean;
  v24: LongInt;
  v25: Boolean;
begin
  v0 := 42;
  v1 := 6364136223846793005;
  v2 := 1442695040888963407;
  v3 := 1000;
  v4 := lcg_0(v1, v2, v3, v0);
  Write('lcg ', v4, #10);
  v5 := 9223372036854775807;
  v6 := (-9223372036854775807);
  v7 := 18446744073709551615;
  v8 := v6 - 1;
  v9 := v7 + 2;
  Write('max ', v5, ' min ', v8, ' wrap ', v9, #10);
  v10 := (-9007199254740993);
  v11 := 7;
  v12 := v10 div v11;
  v13 := v10 mod v11;
  Write('div ', v12, ' mod ', v13, #10);
  v14 := SarInt64(v10, 3);
  v15 := v4 shr 60;
  Write('shl ', 4611686018427387904, ' shr ', v14, ' ushr ', v15, #10);
  v16 := v4 and 18446744069414584320;
  v17 := v10 or 255;
  v18 := v4 xor v1;
  Write('and ', v16, ' or ', v17, ' xor ', v18, #10);
  v19 := 1E+18;
  v20 := Int64(Trunc(v19));
  v21 := LongWord(v4);
  v22 := v10;
  v23 := v22 < 0.0;
  if v23 then begin
      v24 := 1;
  end else begin
      v24 := 0;
  end;
  Write('conv ', v20, ' ', v21, ' ', v24, #10);
  v25 := v4 > v1;
  if v25 then begin
      Result := 1;
  end else begin
      Result := 0;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
