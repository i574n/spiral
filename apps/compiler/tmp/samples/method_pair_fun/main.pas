program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TTuple0 = record f0: TFun0; f1: TFun0; end;
  Tleft_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  Tright_c1 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function ClosureCreate1(v0: LongInt): TFun0; forward;
function method0(v0: LongInt; v1: LongInt): TTuple0; forward;
function TupleCreate0(f0: TFun0; f1: TFun0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tleft_c0.Invoke(v1: LongInt): LongInt;
var
  v2: Boolean;
  v3: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := 0;
  end else begin
      v3 := v1 + v0;
      Result := v3;
  end;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tleft_c0;
begin
  c := Tleft_c0.Create; c.v0 := v0;
  Result := c;
end;
function Tright_c1.Invoke(v1: LongInt): LongInt;
var
  v2: Boolean;
  v3: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := 0;
  end else begin
      v3 := v1 + v0;
      Result := v3;
  end;
end;
function ClosureCreate1(v0: LongInt): TFun0;
var c: Tright_c1;
begin
  c := Tright_c1.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: LongInt; v1: LongInt): TTuple0;
var
  v2: TFun0;
  v3: TFun0;
begin
  v2 := ClosureCreate0(v0);
  v3 := ClosureCreate1(v1);
  Result := TupleCreate0(v2, v3);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: TFun0;
  tmp4: TTuple0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: Boolean;
begin
  v0 := 3;
  v1 := 4;
  tmp4 := method0(v0, v1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := v2.Invoke(0);
  v5 := v3.Invoke(0);
  v6 := v4 + v5;
  v7 := v6 = 7;
  if v7 then begin
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
