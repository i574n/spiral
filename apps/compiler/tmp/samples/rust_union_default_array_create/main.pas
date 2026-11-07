program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: AnsiString; end;
  TTuple0 = record f0: AnsiString; f1: TUS0; f2: Boolean; end;
  TArray0 = array of TTuple0;
function US0_Nothing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Just(a0: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: AnsiString; f1: TUS0; f2: Boolean): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1; Result.f2 := f2;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TArray0;
  tmp2: TArray0;
  v2: AnsiString;
  v3: AnsiString;
  v4: TUS0;
  v5: AnsiString;
  v6: TUS0;
  v7: AnsiString;
  v8: TUS0;
  v9: Boolean;
  tmp11: TTuple0;
  v10: AnsiString;
  v11: Boolean;
begin
  v0 := 2;
  tmp2 := nil;
  SetLength(tmp2, v0);
  v1 := tmp2;
  v2 := 'a';
  v3 := 'x';
  v4 := US0_Just(v3);
  v1[0] := TupleCreate0(v2, v4, True);
  v5 := 'b';
  v6 := US0_Nothing;
  v1[1] := TupleCreate0(v5, v6, False);
  tmp11 := v1[0];
  v7 := tmp11.f0;
  v8 := tmp11.f1;
  v9 := tmp11.f2;
  case v8.tag of
      1: begin
          v10 := v8.c1_0;
          v11 := v10 = 'x';
          if v11 then begin
              Result := 7;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          Result := 2;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
