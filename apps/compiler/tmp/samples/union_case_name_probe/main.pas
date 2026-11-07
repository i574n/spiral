program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: Double; c1_0: Double; end;
  TArray0 = array of AnsiString;
function US0_Circle(a0: Double): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Square(a0: Double): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Dot: TUS0;
begin
  Result.tag := 2; 
end;
function SpiralMain: LongInt;
var
  v0: Double;
  v1: TUS0;
  v2: Double;
  v3: TUS0;
  v4: TUS0;
  v8: AnsiString;
  v9: AnsiString;
  v10: AnsiString;
  v11: TArray0;
  tmp9: TArray0;
  v12: LongInt;
  v13: AnsiString;
  v14: Boolean;
  v19: Boolean;
  v15: TArray0;
  tmp15: TArray0;
  v16: LongInt;
  v17: AnsiString;
  v18: Boolean;
  v24: Boolean;
  v20: TArray0;
  tmp21: TArray0;
  v21: LongInt;
  v22: AnsiString;
  v23: Boolean;
begin
  v0 := 1.5;
  v1 := US0_Circle(v0);
  v2 := 2.5;
  v3 := US0_Square(v2);
  v4 := US0_Dot;
  v8 := 'Circle';
  v9 := 'Square';
  v10 := 'Dot';
  SetLength(tmp9, 3);
  tmp9[0] := v8;
  tmp9[1] := v9;
  tmp9[2] := v10;
  v11 := tmp9;
  v12 := v1.tag;
  v13 := v11[v12];
  v14 := v13 = 'Circle';
  if v14 then begin
      SetLength(tmp15, 3);
      tmp15[0] := v8;
      tmp15[1] := v9;
      tmp15[2] := v10;
      v15 := tmp15;
      v16 := v3.tag;
      v17 := v15[v16];
      v18 := v17 = 'Square';
      v19 := v18;
  end else begin
      v19 := False;
  end;
  if v19 then begin
      SetLength(tmp21, 3);
      tmp21[0] := v8;
      tmp21[1] := v9;
      tmp21[2] := v10;
      v20 := tmp21;
      v21 := v4.tag;
      v22 := v20[v21];
      v23 := v22 = 'Dot';
      v24 := v23;
  end else begin
      v24 := False;
  end;
  if v24 then begin
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
