program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
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
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v11: Boolean;
  v10: Boolean;
  v13: Boolean;
  v12: Boolean;
  v15: Boolean;
  v14: Boolean;
begin
  v0 := #195#169;
  v1 := 'x';
  v2 := v0 + v1;
  v3 := #195#169'x';
  v4 := #195#169'y';
  v5 := '';
  v6 := StringSlice(v3, 1, 0);
  v7 := v2 = v3;
  if v7 then begin
      v8 := v2 <> v4;
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
      v10 := v0 <> v3;
      v11 := v10;
  end else begin
      v11 := False;
  end;
  if v11 then begin
      v12 := v5 = v6;
      v13 := v12;
  end else begin
      v13 := False;
  end;
  if v13 then begin
      v14 := v5 <> v0;
      v15 := v14;
  end else begin
      v15 := False;
  end;
  if v15 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
