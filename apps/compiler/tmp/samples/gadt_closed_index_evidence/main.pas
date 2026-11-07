program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH1 = class;
  TUH1 = class(TSpiralRc) tag: LongInt; c1_0: TUH0; procedure DropFields; override; end;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: TUH1; procedure DropFields; override; end;
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
function no_depth_1(v0: TUH0): LongInt; forward;
function yes_depth_0(v0: TUH1): LongInt; forward;
procedure TUH1.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH1_Eps_shared: TUH1 = nil;
function UH1_Eps: TUH1;
begin
  if UH1_Eps_shared = nil then begin UH1_Eps_shared := TUH1.Create; UH1_Eps_shared.tag := 0; UH1_Eps_shared.refc := High(LongInt) div 2; end;
  Result := UH1_Eps_shared;
end;
function UH1_NotNo(a0: TUH0): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH0_Never_shared: TUH0 = nil;
function UH0_Never: TUH0;
begin
  if UH0_Never_shared = nil then begin UH0_Never_shared := TUH0.Create; UH0_Never_shared.tag := 0; UH0_Never_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Never_shared;
end;
function UH0_NotYes(a0: TUH1): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function no_depth_1(v0: TUH0): LongInt;
var
  v1: TUH1;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 2;
      end;
      1: begin
          v1 := v0.c1_0;
          SpiralRetain(v1);
          SpiralRetain(v1);
          SpiralRelease(v0);
          v2 := yes_depth_0(v1);
          SpiralRelease(v1);
          v3 := 1 + v2;
          Result := v3;
      end;
  end;
end;
function yes_depth_0(v0: TUH1): LongInt;
var
  v1: TUH0;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      0: begin
          SpiralRelease(v0);
          Result := 1;
      end;
      1: begin
          v1 := v0.c1_0;
          SpiralRetain(v1);
          SpiralRetain(v1);
          SpiralRelease(v0);
          v2 := no_depth_1(v1);
          SpiralRelease(v1);
          v3 := 1 + v2;
          Result := v3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: TUH1;
  v2: TUH0;
  v3: TUH1;
begin
  v0 := UH0_Never;
  SpiralRetain(v0);
  v1 := UH1_NotNo(v0);
  SpiralRetain(v1);
  SpiralRelease(v0);
  v2 := UH0_NotYes(v1);
  SpiralRetain(v2);
  SpiralRelease(v1);
  v3 := UH1_NotNo(v2);
  SpiralRelease(v2);
  Result := yes_depth_0(v3);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH1_Eps_shared <> nil then UH1_Eps_shared.Free;
  if UH0_Never_shared <> nil then UH0_Never_shared.Free;
  Halt(SpiralExitCode);
end.
