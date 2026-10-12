program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TTuple0 = record f0: TUS0; f1: THeap0; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; v1: THeap0; function Invoke(v2: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: LongInt; v1: THeap0): TFun0; forward;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: TUS0; f1: THeap0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v2: LongInt): TTuple0;
var
  v3: Boolean;
  v4: TUS0;
  v5: TUS0;
begin
  v3 := v2 = 0;
  if v3 then begin
      v4 := US0_None;
      Result := TupleCreate0(v4, v1);
  end else begin
      v5 := US0_Some(v0);
      Result := TupleCreate0(v5, v1);
  end;
end;
function ClosureCreate0(v0: LongInt; v1: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: THeap0;
  v3: TFun0;
  v4: TUS0;
  v5: THeap0;
  tmp6: TTuple0;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := HeapCreate0(v1);
  v3 := ClosureCreate0(v0, v2);
  tmp6 := v3.Invoke(1);
  v4 := tmp6.f0;
  v5 := tmp6.f1;
  case v4.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v6 := v4.c1_0;
          v7 := v5.l0;
          v8 := v6 + v7;
          v9 := v8 = 7;
          if v9 then begin
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
  Halt(SpiralMain);
end.
