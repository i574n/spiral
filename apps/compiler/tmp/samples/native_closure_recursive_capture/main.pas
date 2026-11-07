program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TFun0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: LongInt; c1_1: TUH0; c1_2: TUH0; procedure DropFields; override; end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: TUH0; function Invoke(v1: LongInt): LongInt; override; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function sum_0(v0: TUH0): LongInt; forward;
function ClosureCreate0(v0: TUH0): TFun0; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_1); SpiralRelease(c1_2);
end;
var UH0_Leaf_shared: TUH0 = nil;
function UH0_Leaf: TUH0;
begin
  if UH0_Leaf_shared = nil then begin UH0_Leaf_shared := TUH0.Create; UH0_Leaf_shared.tag := 0; UH0_Leaf_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Leaf_shared;
end;
function UH0_Node(a0: LongInt; a1: TUH0; a2: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1; Result.c1_2 := a2;
end;
procedure Tf_c0.DropFields;
begin
  SpiralRelease(v0);
end;
function sum_0(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: TUH0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 0;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          v3 := v0.c1_2;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRetain(v3);
          SpiralRelease(v0);
          v4 := sum_0(v2);
          SpiralRetain(v3);
          SpiralRelease(v2);
          v5 := sum_0(v3);
          SpiralRelease(v3);
          v6 := v4 + v5;
          v7 := v1 + v6;
          Result := v7;
      end;
  end;
end;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  SpiralRetain(v0);
  v2 := sum_0(v0);
  v3 := v2 + v1;
  Result := v3;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: TUH0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: LongInt;
  v2: TUH0;
  v3: TFun0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := UH0_Leaf;
  v1 := 2;
  SpiralRetain(v0);
  SpiralRetain(v0);
  v2 := UH0_Node(v1, v0, v0);
  SpiralRetain(v2);
  SpiralRelease(v0);
  v3 := ClosureCreate0(v2);
  SpiralRetain(v3);
  SpiralRelease(v2);
  v4 := v3.Invoke(19);
  SpiralRetain(v3);
  v5 := v3.Invoke(19);
  SpiralRelease(v3);
  v6 := v4 + v5;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_Leaf_shared <> nil then UH0_Leaf_shared.Free;
  Halt(SpiralExitCode);
end.
