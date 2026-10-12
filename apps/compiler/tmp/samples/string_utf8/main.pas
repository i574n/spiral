program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function StringSlice(const value: AnsiString; from, upto: Int64): AnsiString;
var len: Int64;
begin
  len := Length(value);
  if (from < 0) or (from > len) or (upto < from - 1) or (upto >= len) then Halt(3);
  if upto < from then Exit('');
  if ((Ord(value[from + 1]) and $C0) = $80) or ((upto + 1 < len) and ((Ord(value[upto + 2]) and $C0) = $80)) then Halt(3);
  Result := Copy(value, from + 1, upto - from + 1);
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: AnsiChar;
  v3: AnsiChar;
  v4: AnsiString;
  v5: AnsiString;
  v6: LongInt;
  v7: AnsiString;
  v8: AnsiChar;
  v9: AnsiString;
  v10: LongInt;
  v11: AnsiString;
  v12: LongInt;
  v13: AnsiString;
  v14: LongInt;
  v15: Boolean;
  v16: Boolean;
  v18: Boolean;
  v17: Boolean;
  v20: Boolean;
  v19: Boolean;
  v22: Boolean;
  v21: Boolean;
  v24: Boolean;
  v23: Boolean;
  v26: Boolean;
  v25: Boolean;
begin
  v0 := #195#169;
  v1 := LongInt(Length(v0));
  v2 := v0[0 + 1];
  v3 := v0[1 + 1];
  v4 := 'x';
  v5 := v0 + v4;
  v6 := LongInt(Length(v5));
  v7 := 'ab';
  v8 := v7[0 + 1];
  v9 := StringSlice(v7, 0, 0);
  v10 := LongInt(Length(v9));
  v11 := StringSlice(v7, 1, 0);
  v12 := LongInt(Length(v11));
  v13 := StringSlice(v0, 0, 1);
  v14 := LongInt(Length(v13));
  v15 := v2 = v3;
  if v15 then begin
      Result := 1;
  end else begin
      v16 := v1 = 2;
      if v16 then begin
          v17 := v8 = 'a';
          v18 := v17;
      end else begin
          v18 := False;
      end;
      if v18 then begin
          v19 := v6 = 3;
          v20 := v19;
      end else begin
          v20 := False;
      end;
      if v20 then begin
          v21 := v10 = 1;
          v22 := v21;
      end else begin
          v22 := False;
      end;
      if v22 then begin
          v23 := v12 = 0;
          v24 := v23;
      end else begin
          v24 := False;
      end;
      if v24 then begin
          v25 := v14 = 2;
          v26 := v25;
      end else begin
          v26 := False;
      end;
      if v26 then begin
          Result := 0;
      end else begin
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
