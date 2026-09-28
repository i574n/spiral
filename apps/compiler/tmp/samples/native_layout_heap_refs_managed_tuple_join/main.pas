program SpiralGenerated;
{$mode objfpc}{$H+}
type
  TSpiralRecursiveNode = class
  public
    value: LongInt;
    next: TSpiralRecursiveNode;
    constructor Create(aValue: LongInt; aNext: TSpiralRecursiveNode);
    function CloneNode: TSpiralRecursiveNode;
    destructor Destroy; override;
  end;
  TSpiralManagedTuple = class
  public
    item: TSpiralRecursiveNode;
    score: LongInt;
    constructor Create(aItem: TSpiralRecursiveNode; aScore: LongInt);
    function CloneTuple: TSpiralManagedTuple;
    destructor Destroy; override;
  end;
  TSpiralHeapRefs = class
  public
    pair: TSpiralManagedTuple;
    q: LongInt;
    w: LongInt;
    constructor Create;
    destructor Destroy; override;
  end;

constructor TSpiralRecursiveNode.Create(aValue: LongInt; aNext: TSpiralRecursiveNode);
begin
  inherited Create;
  value := aValue;
  next := aNext;
end;

function TSpiralRecursiveNode.CloneNode: TSpiralRecursiveNode;
begin
  if Assigned(next) then
    Result := TSpiralRecursiveNode.Create(value, next.CloneNode)
  else
    Result := TSpiralRecursiveNode.Create(value, nil);
end;

destructor TSpiralRecursiveNode.Destroy;
begin
  next.Free;
  next := nil;
  inherited Destroy;
end;

constructor TSpiralManagedTuple.Create(aItem: TSpiralRecursiveNode; aScore: LongInt);
begin
  inherited Create;
  item := aItem;
  score := aScore;
end;

function TSpiralManagedTuple.CloneTuple: TSpiralManagedTuple;
begin
  if Assigned(item) then
    Result := TSpiralManagedTuple.Create(item.CloneNode, score)
  else
    Result := TSpiralManagedTuple.Create(nil, score);
end;

destructor TSpiralManagedTuple.Destroy;
begin
  item.Free;
  item := nil;
  inherited Destroy;
end;

constructor TSpiralHeapRefs.Create;
begin
  inherited Create;
  pair := TSpiralManagedTuple.Create(TSpiralRecursiveNode.Create(11, nil), 13);
  q := 5;
  w := 6;
end;

destructor TSpiralHeapRefs.Destroy;
begin
  pair.Free;
  pair := nil;
  inherited Destroy;
end;

procedure SpiralAssignManagedTuple(var target: TSpiralManagedTuple; const value: TSpiralManagedTuple);
var
  nextValue: TSpiralManagedTuple;
begin
  if Assigned(value) then nextValue := value.CloneTuple else nextValue := nil;
  target.Free;
  target := nextValue;
end;

function SpiralManagedTupleOptionValue(const value: TSpiralManagedTuple): LongInt;
begin
  if Assigned(value) and Assigned(value.item) then Result := value.item.value else Result := 0;
end;

function SpiralManagedTupleScalar(const value: TSpiralManagedTuple): LongInt;
begin
  if Assigned(value) then Result := value.score else Result := 0;
end;

function SpiralMain: LongInt;
var
  a, b: TSpiralHeapRefs;
  next_managed_tuple_value: TSpiralManagedTuple;
begin
  a := TSpiralHeapRefs.Create;
  try
    b := a;
    if a.q = 5 then begin
      next_managed_tuple_value := TSpiralManagedTuple.Create(TSpiralRecursiveNode.Create(19, nil), 23);
      try
        SpiralAssignManagedTuple(a.pair, next_managed_tuple_value);
      finally
        next_managed_tuple_value.Free;
        next_managed_tuple_value := nil;
      end;
    end else begin
      next_managed_tuple_value := TSpiralManagedTuple.Create(nil, 31);
      try
        SpiralAssignManagedTuple(a.pair, next_managed_tuple_value);
      finally
        next_managed_tuple_value.Free;
        next_managed_tuple_value := nil;
      end;
    end;
    a.q := SpiralManagedTupleOptionValue(b.pair);
    a.w := SpiralManagedTupleScalar(a.pair);
    Result := LongInt(a.q + a.w);
  finally
    a.Free;
  end;
end;

begin
  Halt(SpiralMain);
end.
