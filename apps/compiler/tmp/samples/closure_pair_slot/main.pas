program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TTuple0 = record f0: TUS0; f1: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: TUS0; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v1: LongInt): TTuple0;
var
  v2: Boolean;
  v3: TUS0;
  v4: TUS0;
begin
  v2 := v1 = 0;
  if v2 then begin
      v3 := US0_None;
      Result := TupleCreate0(v3, 0);
  end else begin
      v4 := US0_Some(v0);
      Result := TupleCreate0(v4, v0);
  end;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: TUS0;
  v3: LongInt;
  tmp4: TTuple0;
  v4: LongInt;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 7;
  v1 := ClosureCreate0(v0);
  tmp4 := v1.Invoke(1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  case v2.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v4 := v2.c1_0;
          v5 := v4 = 7;
          if v5 then begin
              v6 := v3 = 7;
              v7 := v6;
          end else begin
              v7 := False;
          end;
          if v7 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
