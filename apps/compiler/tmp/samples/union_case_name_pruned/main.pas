program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
  TArray0 = array of AnsiString;
function SpiralDeclaredTag(tag: LongInt; const declared: array of LongInt): LongInt;
begin
  Result := declared[tag];
end;
function US0_First: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Second: TUS0;
begin
  Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: TUS0;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: TArray0;
  tmp6: TArray0;
  v7: LongInt;
  v8: AnsiString;
  v9: Boolean;
  v14: Boolean;
  v10: TArray0;
  tmp12: TArray0;
  v11: LongInt;
  v12: AnsiString;
  v13: Boolean;
begin
  v0 := US0_First;
  v1 := US0_Second;
  v3 := '';
  v4 := 'First';
  v5 := 'Second';
  SetLength(tmp6, 3);
  tmp6[0] := v3;
  tmp6[1] := v4;
  tmp6[2] := v5;
  v6 := tmp6;
  v7 := SpiralDeclaredTag(v0.tag, [1, 2]);
  v8 := v6[v7];
  v9 := v8 = 'First';
  if v9 then begin
      SetLength(tmp12, 3);
      tmp12[0] := v3;
      tmp12[1] := v4;
      tmp12[2] := v5;
      v10 := tmp12;
      v11 := SpiralDeclaredTag(v1.tag, [1, 2]);
      v12 := v10[v11];
      v13 := v12 = 'Second';
      v14 := v13;
  end else begin
      v14 := False;
  end;
  if v14 then begin
      Result := 42;
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
