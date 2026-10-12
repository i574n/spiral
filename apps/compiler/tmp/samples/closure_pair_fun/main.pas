program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun1 = class;
  TFun1 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TTuple0 = record f0: TFun1; f1: TFun1; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): TTuple0; override; end;
  Tright_c1 = class(TFun1) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
  Tleft_c2 = class(TFun1) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): LongInt; override; end;
function ClosureCreate1(v0: LongInt; v1: LongInt): TFun1; forward;
function ClosureCreate2(v0: LongInt; v1: LongInt): TFun1; forward;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0; forward;
function TupleCreate0(f0: TFun1; f1: TFun1): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tright_c1.Invoke(v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  v3 := v1 = 0;
  if v3 then begin
      Result := 0;
  end else begin
      v4 := v2 + v0;
      Result := v4;
  end;
end;
function ClosureCreate1(v0: LongInt; v1: LongInt): TFun1;
var c: Tright_c1;
begin
  c := Tright_c1.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tleft_c2.Invoke(v2: LongInt): LongInt;
var
  v3: Boolean;
  v4: LongInt;
begin
  v3 := v1 = 0;
  if v3 then begin
      Result := 0;
  end else begin
      v4 := v2 + v0;
      Result := v4;
  end;
end;
function ClosureCreate2(v0: LongInt; v1: LongInt): TFun1;
var c: Tleft_c2;
begin
  c := Tleft_c2.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tf_c0.Invoke(v2: LongInt): TTuple0;
var
  v3: Boolean;
  v4: TFun1;
  v5: TFun1;
  v6: TFun1;
  v7: TFun1;
begin
  v3 := v2 = 0;
  if v3 then begin
      v4 := ClosureCreate1(v1, v2);
      v5 := ClosureCreate2(v0, v2);
      Result := TupleCreate0(v4, v5);
  end else begin
      v6 := ClosureCreate2(v0, v2);
      v7 := ClosureCreate1(v1, v2);
      Result := TupleCreate0(v6, v7);
  end;
end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: TFun1;
  v4: TFun1;
  tmp5: TTuple0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := ClosureCreate0(v0, v1);
  tmp5 := v2.Invoke(1);
  v3 := tmp5.f0;
  v4 := tmp5.f1;
  v5 := v3.Invoke(0);
  v6 := v4.Invoke(0);
  v7 := v5 + v6;
  v8 := v7 = 7;
  if v8 then begin
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
