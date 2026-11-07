program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: TUH0; c1_1: TUH0; procedure DropFields; override; end;
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
function count_0(v0: TUH0): LongInt; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_0); SpiralRelease(c1_1);
end;
var UH0_Leaf_shared: TUH0 = nil;
function UH0_Leaf: TUH0;
begin
  if UH0_Leaf_shared = nil then begin UH0_Leaf_shared := TUH0.Create; UH0_Leaf_shared.tag := 0; UH0_Leaf_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Leaf_shared;
end;
function UH0_Node(a0: TUH0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function count_0(v0: TUH0): LongInt;
var
  v1: TUH0;
  v2: TUH0;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 1;
      end;
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          SpiralRetain(v1);
          SpiralRetain(v1);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := count_0(v1);
          SpiralRetain(v2);
          SpiralRelease(v1);
          v4 := count_0(v2);
          SpiralRelease(v2);
          v5 := v3 + v4;
          Result := v5;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: TUH0;
  v2: TUH0;
  v3: TUH0;
  v4: TUH0;
begin
  v0 := UH0_Leaf;
  v1 := UH0_Leaf;
  v2 := UH0_Leaf;
  SpiralRetain(v1);
  SpiralRetain(v2);
  v3 := UH0_Node(v1, v2);
  SpiralRetain(v0);
  SpiralRetain(v3);
  SpiralRelease(v1);
  SpiralRelease(v2);
  v4 := UH0_Node(v0, v3);
  SpiralRelease(v0);
  SpiralRelease(v3);
  Result := count_0(v4);
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
